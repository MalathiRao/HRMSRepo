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
    [Route("EmployementType")]
    public class EmployementTypesController : Controller
    {

        private readonly ILogger<EmployementTypesController> _logger;
        private readonly IEmployementTypeService _employementTypeService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currUriBasePath;

        public EmployementTypesController(IEmployementTypeService employementTypeService, IHttpContextAccessor httpContextAccessor, ILogger<EmployementTypesController> logger, IConfiguration configuration)
        {
            this._employementTypeService = employementTypeService;
            this._logger = logger;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            _currUriBasePath = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllEmployementType()
        {
            _logger.LogInformation("GetAllEmployementType method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetEmployees service"));
                var result = await _employementTypeService.GetAllEmployementType();
                if (result == null)
                {
                    return NoContent();
                }
                _logger.LogInformation("GetAllEmployementType method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetAllEmployementType: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployementTypeById([FromRoute] int id)
        {
            _logger.LogInformation("GetEmployementTypeById method started");
            try
            {
                _logger.LogInformation("Calling GetEmployementTypeById Service");
                var result = await _employementTypeService.GetEmployementTypeById(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method GetEmployementTypeById: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployementType([FromBody] EmployementTypesDto employementTypesDto)
        {
            _logger.LogInformation("CreateEmployementType method started");
            try
            {
                _logger.LogInformation("Calling CreateEmployementType service");
                var result = await _employementTypeService.CreateEmployementType(employementTypesDto);
                _logger.LogInformation("CreateEmployementType method ended");
                return Created(new Uri(_currUriBasePath + "/EmployementTypes/" + result.EmpTypeID), result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method CreateEmployementType: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployementType([FromBody] EmployementTypesDto employementTypesDto)
        {
            _logger.LogInformation("UpdateEmployementType method started");
            try
            {
                _logger.LogInformation(string.Format("Calling UpdateEmployementType service"));
                var result = await _employementTypeService.UpdateEmployementType(employementTypesDto);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("UpdateEmployementType method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method UpdateEmployementType: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployementTypeById([FromRoute] int id)
        {
            _logger.LogInformation("DeleteEmployementTypeById method started");
            try
            {
                _logger.LogInformation("Calling DeleteEmployementTypeById Service");
                var result = await _employementTypeService.GetEmployementTypeById(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("Calling DeleteEmployementTypeById service");
                var employementdto = await _employementTypeService.DeleteEmployementTypeById(id);
                _logger.LogInformation("DeleteEmployementTypeById method ended");
                return Ok(employementdto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method DeleteEmployementTypeById: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
