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
    [Route("LeaveBalance")]
    public class LeaveBalanceController : ControllerBase
    {
        private readonly ILogger<LeaveBalanceController> _logger;
        private readonly ILeaveService _LeaveService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currUriBasePath;

        public LeaveBalanceController(ILeaveService LeaveService, IHttpContextAccessor httpContextAccessor, ILogger<LeaveBalanceController> logger, IConfiguration configuration)
        {
            this._LeaveService = LeaveService;
            this._logger = logger;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            _currUriBasePath = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GetAllLeaveBalance method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetAllLeaveBalance service"));
                var result = await _LeaveService.GetAllLeaveBalance();
                if (result == null)
                {
                    return NoContent();
                }
                _logger.LogInformation("GetAllLeaveBalance method ended");
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
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            _logger.LogInformation("GetEmployeeById method started");
            try
            {
                _logger.LogInformation("Calling GetEmployeeById Service");
                var result = await _LeaveService.GetAllLeaveBalanceById(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method GetEmployeeById: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LeaveBalanceDto leaveBalanceDto)
        {
            _logger.LogInformation("CreateLeaveBalance method started");
            try
            {
                _logger.LogInformation("Calling CreateLeaveBalance service");
                var result = await _LeaveService.CreateLeaveBalance(leaveBalanceDto);
                _logger.LogInformation("CreateLeaveBalance method ended");
                return Created(new Uri(_currUriBasePath + "/LeaveBalance/" + result.LeaveBalanceID), result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method CreateLeaveBalance: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] LeaveBalanceDto leaveBalanceDto)
        {
            _logger.LogInformation("UpdateLeaveBalance method started");
            try
            {
                _logger.LogInformation(string.Format("Calling UpdateLeaveBalance service"));
                var result = await _LeaveService.UpdateLeaveBalance(leaveBalanceDto);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("UpdateLeaveBalance method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method leaveBalanceDto: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            _logger.LogInformation("DeleteEmployee method started");
            try
            {
                _logger.LogInformation("Calling GetAllLeaveBalanceById Service");
                var result = await _LeaveService.GetAllLeaveBalanceById(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("Calling DeleteLeaveBalance service");
                var employeeDto = await _LeaveService.DeleteLeaveBalance(id);
                _logger.LogInformation("DeleteLeaveBalance method ended");
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method DeleteLeaveBalance: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
