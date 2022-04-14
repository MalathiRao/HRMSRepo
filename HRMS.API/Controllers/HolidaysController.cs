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
    [Route("Holiday")]
    public class HolidaysController : Controller
    {
        private readonly ILogger<HolidaysController> _logger;
        private readonly IHolidayService _HolidayService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currUriBasePath;
        public HolidaysController(IHolidayService holidayService, IHttpContextAccessor httpContextAccessor, ILogger<HolidaysController> logger, IConfiguration configuration)
        {
            this._HolidayService = holidayService;
            this._logger = logger;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            _currUriBasePath = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("GetHoliday method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetHoliday service"));
                var result = await _HolidayService.GetAllHoliday();
                if (result == null)
                {
                    return NoContent();
                }
                _logger.LogInformation("GetHoliday method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetHoliday: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }

        }
        [HttpGet]
        [Route("{Serial}")]
        public async Task<IActionResult> Get([FromRoute] int Serial)
        {
            _logger.LogInformation("GetHolidayById method started");
            try
            {
                _logger.LogInformation(string.Format("Calling GetHolidayById method started"));
                var holiday = await _HolidayService.GetHolidayById(Serial);
                if (holiday == null)
                {
                    return NotFound(holiday);

                }
                return Ok(holiday);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in method GetHolidayById: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HolidayListDto holidayListDto)
        {
            _logger.LogInformation("Creating Holiday method started");
            try
            {
                var holiday = await _HolidayService.CreateHoliday(holidayListDto);
                _logger.LogInformation("Creating Holiday method ended");
                return Created(new Uri(_currUriBasePath + "/Holiday/" + holiday.Serial), holiday);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method CreateHoliday: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }


        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] HolidayListDto holidayListDto)
        {
            _logger.LogInformation("EditHoliday method started");
            try
            {
                var holiday = await _HolidayService.UpdateHoliday(holidayListDto);
                if (holiday == null)
                {
                    return NotFound(holiday);
                }
                _logger.LogInformation("EditHoliday method ended");
                return Ok(holiday);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method EditHoliday: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }

        }
        [HttpDelete]
        [Route("{Serial}")]
        public async Task<IActionResult> Delete([FromRoute] int Serial)
        {
            _logger.LogInformation("DeleteHoliday method started");
            try
            {
                var holiday = await _HolidayService.DeleteHolidayById(Serial);
                if (holiday == null)
                {
                    return NotFound(holiday);
                }
                _logger.LogInformation("Calling DeleteHoliday service");
                var result = await _HolidayService.DeleteHolidayById(Serial);
                _logger.LogInformation("DeleteHoliday method ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred in method DeleteHoliday: " + ex.StackTrace);
                return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }
}
