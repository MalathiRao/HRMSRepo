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
    [Route("Designation")]
    public class DesignationsController : Controller
    {
        private readonly ILogger<DesignationsController> _logger;
        private readonly IDesignationService _DesignationService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currUriBasePath;
        public DesignationsController(IDesignationService designationService, IHttpContextAccessor httpContextAccessor, ILogger<DesignationsController> logger, IConfiguration configuration)
        {
            this._DesignationService = designationService;
            this._logger = logger;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            _currUriBasePath = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DesignationDto designationDto)
        {
            _logger.LogInformation("Create Designation method started");
            try
            {
                _logger.LogInformation("Calling CreateDesignation service");
                var result = await _DesignationService.CreateDesignation(designationDto);
                _logger.LogInformation("CreateDesignation method ended");
                return Created(new Uri(_currUriBasePath + "/Designation" + result.DesignationID), result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method CreateDesignation: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GetDesignation method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetDesignation service"));
                var result = await _DesignationService.GetAllDesignation();
                if (result == null)
                {
                    return NoContent();
                }
                _logger.LogInformation("GetDesignation method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetEmployees: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet]
        [Route("{DesignationId}")]
        public async Task<IActionResult> GetDesignationById(int DesignationId)
        {
            _logger.LogInformation("GetDesignationById method started");
            try
            {
                _logger.LogInformation(string.Format("GetDesignationById service started"));
                var result = await _DesignationService.GetDesignationById(DesignationId);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("GetDesignationById method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetDesignationById: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] DesignationDto designationDto)
        {
            _logger.LogInformation("Designation edit method started");
            try
            {
                var result = await _DesignationService.UpdateDesignation(designationDto);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("Designation edit method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method edit Designation: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete]
        [Route("{DesignationId}")]
        public async Task<IActionResult> Delete([FromRoute] int DesignationId)
        {
            _logger.LogInformation("DeleteDesignation method started");
            try
            {
                var result = await _DesignationService.DeleteDesignationById(DesignationId);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("DeleteDesignation method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method  DeleteDesignation: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }


        }

    }
}
