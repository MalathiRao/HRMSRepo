using HRMS.Web.GoogleOuath;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;

namespace HRMS.Web.Controllers
{
    //[AllowAnonymous, Route("Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        [TempData]
        public string ErrorMessage { get; set; }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GoogleLogin(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,

                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            string redirectUrl = Url.Action("ExternalLoginCallBack", "Account",
                                                new { ReturnUrl = returnUrl });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
           
            return new ChallengeResult(provider, properties);
        }
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallBack(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            LoginViewModel loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,

                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider:{remoteError}");
                return View("Login", loginViewModel);
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error Loading external login Information.");
                return View("Login", loginViewModel);
            }

            var signresult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            var email = info.Principal.FindFirst(ClaimTypes.Email);
            TempData["Email"] = email.Value;
            if (signresult.Succeeded)
            {

                // return LocalRedirect(returnUrl);
                return RedirectToAction("Index", "Client");
            }
            else
            {
                //var email = info.Principal.FindFirst(ClaimTypes.Email);
                if (email != null)
                {
                    var user = await _userManager.FindByEmailAsync(email.ToString());
                    if (user == null)
                    {
                        user = new IdentityUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.GivenName) + info.Principal.FindFirstValue(ClaimTypes.Surname),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };
                        await _userManager.CreateAsync(user);
                    }
                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                ViewBag.ErrorTitle = $"Email claim not recieved form:{info.ProviderKey}";
                ViewBag.ErrrorMessage = "please contact support";
                return View("Error");
            }

            return View("Login", loginViewModel);
        }

    }
}
