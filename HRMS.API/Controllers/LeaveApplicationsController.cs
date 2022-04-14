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
    [Route("LeaveApplications")]
    public class LeaveApplicationsController : Controller
    {
        private readonly ILogger<LeaveApplicationsController> _logger;
        private readonly ILeaveService _leaveService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currUriBasePath;

        public LeaveApplicationsController(ILeaveService leaveService, IHttpContextAccessor httpContextAccessor, ILogger<LeaveApplicationsController> logger, IConfiguration configuration)
        {
            this._leaveService = leaveService;
            this._logger = logger;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            _currUriBasePath = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
        }

        //LeaveApplications
        //get
        [HttpGet]
        public async Task<IActionResult> GetAllLeaves()
        {
            _logger.LogInformation("GetAllLeaves method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetAllLeaves service"));
                var result = await _leaveService.GetAllLeaves();
                if (result == null)
                {
                    return NoContent();
                }
                _logger.LogInformation("GetAllLeaves method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetEmployees: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        //GetById
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            _logger.LogInformation("CreateEmployeeLeaves method started");
            try
            {
                _logger.LogInformation("Calling CreateEmployeeLeaves Service");
                var result = await _leaveService.GetEmployeeLeavesById(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method CreateEmployeeLeaves: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        //CreateLeaves
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LeaveApplicationsDto leaveApplicationsDto)
        {
            _logger.LogInformation("CreateEmployeeLeaves method started");
            try
            {
                _logger.LogInformation("Calling CreateEmployeeLeaves service");
                var createLeaves = await _leaveService.CreateEmployeeLeaves(leaveApplicationsDto);
                _logger.LogInformation("CreateAllLeaveTypesId method ended");
                return Created(new Uri(_currUriBasePath + "/LeaveApplications/" + createLeaves.LeaveAppId), createLeaves);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method CreateEmployeeLeaves: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        //Edit
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] LeaveApplicationsDto leaveApplicationsDto)
        {
            _logger.LogInformation("UpdateEmployeeLeaves method started");
            try
            {
                _logger.LogInformation(string.Format("Calling UpdateAllLeaveTypesId service"));
                var result = await _leaveService.UpdateEmployeeLeaves(leaveApplicationsDto);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("UpdateEmployeeLeaves method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method EditEmployee: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            _logger.LogInformation("DeleteEmployeeLeavesById method started");
            try
            {
                _logger.LogInformation("Calling GetEmployeeLeavesById Service");
                var result = await _leaveService.GetAllLeaveTypesByID(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("Calling DeleteEmployeeLeavesById service");
                var employeeDto = await _leaveService.DeleteEmployeeLeavesById(id);
                _logger.LogInformation("DeleteEmployeeLeavesById method ended");
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method DeleteEmployeeLeavesById: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
