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
    [Route("LeaveTypes")]
    public class LeaveTypesController : ControllerBase
    {
        private readonly ILogger<LeaveTypesController> _logger;
        private readonly ILeaveService _leaveService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currUriBasePath;

        public LeaveTypesController(ILeaveService leaveService, IHttpContextAccessor httpContextAccessor, ILogger<LeaveTypesController> logger, IConfiguration configuration)
        {
            this._leaveService = leaveService;
            this._logger = logger;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            _currUriBasePath = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
        }
        //get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GetLeaveTypes method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetEmployees service"));
                var result = await _leaveService.GetAllLeaveTypes();
                if (result == null)
                {
                    return NoContent();
                }
                _logger.LogInformation("GetLeaveTypes method ended");
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
            _logger.LogInformation("GetAllLeaveTypesByID method started");
            try
            {
                _logger.LogInformation("Calling GetAllLeaveTypesByID Service");
                var result = await _leaveService.GetAllLeaveTypesByID(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method GetAllLeaveTypesByID: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        //Create
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LeaveTypesDto leaveTypesDto)
        {
            _logger.LogInformation("CreateAllLeaveTypesId method started");
            try
            {
                _logger.LogInformation("Calling CreateAllLeaveTypesId service");
                var result = await _leaveService.CreateAllLeaveTypesId(leaveTypesDto);
                _logger.LogInformation("CreateAllLeaveTypesId method ended");
                return Created(new Uri(_currUriBasePath + "/LeaveTypes/" + result.LeaveTypeID), result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method CreateAllLeaveTypesId: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        //Edit
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] LeaveTypesDto leaveTypesDto)
        {
            _logger.LogInformation("UpdateAllLeaveTypesId method started");
            try
            {
                _logger.LogInformation(string.Format("Calling UpdateAllLeaveTypesId service"));
                var result = await _leaveService.UpdateAllLeaveTypesId(leaveTypesDto);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("UpdateAllLeaveTypesId method ended");
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
            _logger.LogInformation("DeleteAllLeaveTypesId method started");
            try
            {
                _logger.LogInformation("Calling GetAllLeaveTypesByID Service");
                var result = await _leaveService.GetAllLeaveTypesByID(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("Calling DeleteAllLeaveTypesId service");
                var employeeDto = await _leaveService.DeleteAllLeaveTypesId(id);
                _logger.LogInformation("DeleteAllLeaveTypesId method ended");
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method DeleteAllLeaveTypesId: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

    }
}
