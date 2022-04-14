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
    [Route("Projects")]
    public class ProjectsController : Controller
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly IProjectService _projectService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currUriBasePath;

        public ProjectsController(IProjectService projectService, IHttpContextAccessor httpContextAccessor, ILogger<ProjectsController> logger, IConfiguration configuration)
        {
            this._projectService = projectService;
            this._logger = logger;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            _currUriBasePath = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GetAllProjects method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetAllProjects service"));
                var result = await _projectService.GetAllProjects();
                if (result == null)
                {
                    return NoContent();
                }
                _logger.LogInformation("GetAllProjects method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetAllProjects: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetProjectsByProjectId([FromRoute] int id)
        {
            _logger.LogInformation("GetProjectsByProjectId method started");
            try
            {
                _logger.LogInformation("Calling GetProjectsByProjectId Service");
                var result = await _projectService.GetProjectsByProjectId(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method GetProjectsByProjectId: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectsDto projectsDto)
        {
            _logger.LogInformation("CreateProject method started");
            try
            {
                _logger.LogInformation("Calling CreateProject service");
                var result = await _projectService.CreateProject(projectsDto);
                _logger.LogInformation("CreateProject method ended");
                return Created(new Uri(_currUriBasePath + "/Projects/" + result.ProjectId), result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method CreateProject: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ProjectsDto projectsDto)
        {
            _logger.LogInformation("Editproject method started");
            try
            {
                _logger.LogInformation(string.Format("Calling Editproject service"));
                var result = await _projectService.UpdateProject(projectsDto);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("Editproject method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method Editproject: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            _logger.LogInformation("GetProjectsByProjectId method started");
            try
            {
                _logger.LogInformation("Calling GetProjectsByProjectId Service");
                var result = await _projectService.GetProjectsByProjectId(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("Calling DeleteProjectByProjectId service");
                var prjctdto = await _projectService.DeleteProjectByProjectId(id);
                _logger.LogInformation("DeleteEmployee method ended");
                return Ok(prjctdto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method DeleteProject: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
