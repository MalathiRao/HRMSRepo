using HRMS.API.Dtos;
using HRMS.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HRMS.API.Controllers
{
    [Route("ContactDetails")]
    public class ContactDetailsController : Controller
    {
        
        private readonly ILogger<ContactDetailsController> _logger;
        private readonly IContactDetailsService _contactDetailService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currUriBasePath;

        public ContactDetailsController(IContactDetailsService contactDetailsService, IHttpContextAccessor httpContextAccessor, ILogger<ContactDetailsController> logger, IConfiguration configuration)
        {
            this._contactDetailService = contactDetailsService;
            this._logger = logger;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            _currUriBasePath = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GetAllContactDetails method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetAllContactDetails service"));
                var result = await _contactDetailService.GetAllContactDetails();
                if (result == null)
                {
                    return NoContent();
                }
                _logger.LogInformation("GetAllContactDetails method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetAllContactDetails: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetContactdetailsbyId([FromRoute] int id)
        {
            _logger.LogInformation("GetContactdetailsbyId method started");
            try
            {
                _logger.LogInformation("Calling GetContactdetailsbyId Service");
                var result = await _contactDetailService.GetContactDetailsById(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method GetContactdetailsbyId: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactdetails([FromBody] ContactDetailsDto contactdetailsDto)
        {
            _logger.LogInformation("CreateContactdetails method started");
            try
            {
                _logger.LogInformation("Calling CreateContactdetails service");
                var result = await _contactDetailService.CreateContactDetails(contactdetailsDto);
                _logger.LogInformation("CreateContactdetails method ended");
                return Created(new Uri(_currUriBasePath + "/ContactDetails/" + result.ContactID), result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method CreateContactdetails: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContactdetail([FromBody] ContactDetailsDto contactdetailsDto)
        {
            _logger.LogInformation("UpdateContactdetail method started");
            try
            {
                _logger.LogInformation(string.Format("Calling UpdateContactdetail service"));
                var result = await _contactDetailService.UpdateContactDetails(contactdetailsDto);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("UpdateContactdetail method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method UpdateContactdetail: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteContactdetailsById([FromRoute] int id)
        {
            _logger.LogInformation("DeleteContactdetailsById method started");
            try
            {
                _logger.LogInformation("Calling DeleteContactdetailsById Service");
                var result = await _contactDetailService.GetContactDetailsById(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("Calling DeleteContactdetailsById service");
                var employeeDto = await _contactDetailService.DeleteContactDetailsById(id);
                _logger.LogInformation("DeleteEmployee method ended");
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method DeleteContactdetailsById: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
