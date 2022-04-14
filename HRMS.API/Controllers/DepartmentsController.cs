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
    [Route("Department")]
    public class DepartmentsController : Controller
    {
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IDepartmentService _DepartmentService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currUriBasePath;
        public DepartmentsController(IDepartmentService departmentService, IHttpContextAccessor httpContextAccessor, ILogger<DepartmentsController> logger, IConfiguration configuration)
        {
            this._DepartmentService = departmentService;
            this._logger = logger;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            _currUriBasePath = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GetDepartment method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetDepartment service"));
                var result = await _DepartmentService.GetAllDepartments();
                if (result == null)
                {
                    return NoContent();
                }
                _logger.LogInformation("GetDepartment method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetDepartment: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet]
        [Route("{DeptId}")]
        public async Task<IActionResult> Get([FromRoute] int DeptId)
        {
            _logger.LogInformation("GetDepartmentByDeptId method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetDepartmentByDeptId service"));
                var result = await _DepartmentService.GetDepartmentById(DeptId);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("GetDepartmentByDeptId method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetDepartmentById:" + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartmentDto departmentDto)
        {
            _logger.LogInformation("Creating Department method started ");
            try
            {
                var result = await _DepartmentService.CreateDepartment(departmentDto);
                _logger.LogInformation("Creating Department method ended");
                return Created(new Uri(_currUriBasePath + "/Department/" + result.DeptID), result);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in create method Department:" + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] DepartmentDto departmentDto)
        {
            _logger.LogInformation("Edit Department method started");
            try
            {
                var result = await _DepartmentService.UpdateDepartment(departmentDto);
                if (result == null)
                {

                    return NotFound(result);
                }
                _logger.LogInformation("Edit Department method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Edit method Department:" + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete]
        [Route("{DeptId}")]
        public async Task<IActionResult> Delete([FromRoute] int DeptId)
        {
            _logger.LogInformation("Deleting Department method started");
            try
            {
                var result = await _DepartmentService.DeleteDepartmentById(DeptId);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("Deleting Department method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Delete method Department:" + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
