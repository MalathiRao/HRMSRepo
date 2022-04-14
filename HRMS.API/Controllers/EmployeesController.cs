using HRMS.API.Dtos;
using HRMS.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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
    [Route("Employees")]
    public class EmployeesController : Controller
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currUriBasePath;

        public EmployeesController(IEmployeeService employeeService, IHttpContextAccessor httpContextAccessor,ILogger<EmployeesController> logger,IConfiguration configuration)
        {
            this._employeeService = employeeService;
            this._logger = logger;           
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            _currUriBasePath = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GetEmployees method started");
            try
            {                
                _logger.LogInformation(string.Format("Calling GetEmployees service"));
                var result = await _employeeService.GetAllEmployees();
                if (result == null)
                {
                    return NoContent();
                }
                _logger.LogInformation("GetEmployees method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetEmployees: "+ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            _logger.LogInformation("GetEmployeeById method started");                     
            try
            {
                _logger.LogInformation("Calling GetEmployeeById Service");
                var result = await _employeeService.GetEmployeeById(id);
                if(result==null)
                {
                    return NotFound(result);
                }                
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error occurred in method GetEmployeeById: "+ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }            
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EmployeeDto employeeDto)
        {
            _logger.LogInformation("CreateEmployee method started");            
            try
            {
                _logger.LogInformation("Calling CreateEmployee service");
                var result = await _employeeService.CreateEmployee(employeeDto);
                _logger.LogInformation("CreateEmployee method ended");
                return Created(new Uri(_currUriBasePath+ "/Employees/"+result.EmpID),result);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error occurred in method CreateEmployee: "+ ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]EmployeeDto employeeDto)
        {
            _logger.LogInformation("EditEmployees method started");            
            try
            {
                _logger.LogInformation(string.Format("Calling EditEmployee service"));
                var result = await _employeeService.UpdateEmployee(employeeDto);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("EditEmployees method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method EditEmployee: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            _logger.LogInformation("DeleteEmployee method started");           
            try
            {
                _logger.LogInformation("Calling GetEmployeeById Service");
                var result = await _employeeService.GetEmployeeById(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("Calling DeleteEmployee service");
                var employeeDto = await _employeeService.DeleteEmployeeById(id);
                _logger.LogInformation("DeleteEmployee method ended");
                return Ok(employeeDto);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error occurred in method DeleteEmployee: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }            
        }
    }
}
