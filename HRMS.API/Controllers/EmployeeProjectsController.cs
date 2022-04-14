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

    [Route("EmployeeProjects")]
    public class EmployeeProjectsController : Controller
    {
        private readonly ILogger<EmployeeProjectsController> _logger;
        private readonly IEmployeeProjectService _employeeProjectService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currUriBasePath;

        public EmployeeProjectsController(IEmployeeProjectService employeeProjectService, IHttpContextAccessor httpContextAccessor, ILogger<EmployeeProjectsController> logger, IConfiguration configuration)
        {
            this._employeeProjectService = employeeProjectService;
            this._logger = logger;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            _currUriBasePath = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeProjects()
        {
            _logger.LogInformation("GetAllEmployeeProjects method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetAllEmployeeProjects service"));
                var result = await _employeeProjectService.GetAllEmployeeProjects();
                if (result == null)
                {
                    return NoContent();
                }
                _logger.LogInformation("GetAllEmployeeProjects method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetEmployees: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployeeProjectsById([FromRoute] int id)
        {
            _logger.LogInformation("GetEmployeeProjectsById method started");
            try
            {
                _logger.LogInformation("Calling GetEmployeeProjectsById Service");
                var result = await _employeeProjectService.GetEmployeeProjectsById(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method GetEmployeeProjectsById: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeProjects([FromBody] EmployeeProjectsDto employeeProjectsDto)
        {
            _logger.LogInformation("CreateEmployeeProjects method started");
            try
            {
                _logger.LogInformation("Calling CreateEmployeeProjects service");
                var result = await _employeeProjectService.CreateEmployeeProjects(employeeProjectsDto);
                _logger.LogInformation("CreateEmployeeProjects method ended");
                return Created(new Uri(_currUriBasePath + "/EmployeeProjects/" + result.Serial), result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method CreateEmployeeProjects: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployeeProjects([FromBody] EmployeeProjectsDto employeeProjectsDto)
        {
            _logger.LogInformation("UpdateEmployeeProjects method started");
            try
            {
                _logger.LogInformation(string.Format("Calling UpdateEmployeeProjects service"));
                var result = await _employeeProjectService.UpdateEmployeeProjects(employeeProjectsDto);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("UpdateEmployeeProjects method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method UpdateEmployeeProjects: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployeeProjects([FromRoute] int id)
        {
            _logger.LogInformation("DeleteEmployeeProjectsById method started");
            try
            {
                _logger.LogInformation("Calling GetEmployeeProjectsById Service");
                var result = await _employeeProjectService.GetEmployeeProjectsById(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("Calling DeleteEmployeeProjectsById service");
                var employeePrjctDto = await _employeeProjectService.DeleteEmployeeProjectsById(id);
                _logger.LogInformation("DeleteEmployeeProjectsById method ended");
                return Ok(employeePrjctDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method DeleteEmployeeProjectsById: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
