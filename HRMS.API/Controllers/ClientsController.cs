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
    [Route("Clients")]

    public class ClientsController : Controller
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientService _clientService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currUriBasePath;

        public ClientsController(IClientService clientService, IHttpContextAccessor httpContextAccessor, ILogger<ClientsController> logger, IConfiguration configuration)
        {
            this._clientService = clientService;
            this._logger = logger;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            _currUriBasePath = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GetAllClients method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetClients service"));
                var result = await _clientService.GetAllClients();
                if (result == null)
                {
                    return NoContent();
                }
                _logger.LogInformation("GetClients method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetClients: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            _logger.LogInformation("GetClientById method started");
            try
            {
                _logger.LogInformation("Calling GetClientById Service");
                var result = await _clientService.GetClientById(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method GetClientById: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientDto clientDto)
        {
            _logger.LogInformation("CreateClient method started");
            try
            {
                _logger.LogInformation("Calling CreateClient service");
                var result = await _clientService.CreateClient(clientDto);
                _logger.LogInformation("CreateClient method ended");
                return Created(new Uri(_currUriBasePath + "/Clients/" + result.ClientId), result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method CreateClient: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit([FromBody] ClientDto clientDto)
        {
            _logger.LogInformation("EditClients method started");
            try
            {
                _logger.LogInformation(string.Format("Calling EditClients service"));
                var result = await _clientService.UpdateClient(clientDto);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("EditClients method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method EditClient: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            _logger.LogInformation("DeleteClient method started");
            try
            {
                _logger.LogInformation("Calling GetClientById Service");
                var result = await _clientService.DeleteClientById(id);
                if (result == null)
                {
                    return NotFound(result);
                }
                _logger.LogInformation("Calling DeleteClient service");
                var employeeDto = await _clientService.DeleteClientById(id);
                _logger.LogInformation("DeleteClient method ended");
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method DeleteClient: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
