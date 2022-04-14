using AutoMapper;
using HRMS.API.Dtos;
using HRMS.API.Models;
using HRMS.API.Repositories.UnitOfWork;
using HRMS.API.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HolidayService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public HolidayService(IUnitOfWork unitOfWork, ILogger<HolidayService> logger, IConfiguration configuration, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._configuration = configuration;
            this._mapper = mapper;
        }
        public async Task<HolidayListDto> CreateHoliday(HolidayListDto holidayListDto)
        {
            _logger.LogInformation("CreateHoliday service started");
            var result = await _unitOfWork.HolidayListRepository.InsertAsync(_mapper.Map<HolidayList>(holidayListDto));
            _logger.LogInformation("CreateHoliday service ended");
            return _mapper.Map<HolidayListDto>(result);
        }

        public async Task<HolidayListDto> DeleteHolidayById(int Serial)
        {
            _logger.LogInformation("DeleteHolidayById service started");
            var holiday = await _unitOfWork.HolidayListRepository.Get(x => x.Serial == Serial).FirstOrDefaultAsync();
            if(holiday==null)
            {
                return _mapper.Map<HolidayListDto>(holiday);
            }
            await _unitOfWork.HolidayListRepository.DeleteAsync(holiday);
            _logger.LogInformation("DeleteEmployeeById service ended");
            return _mapper.Map<HolidayListDto>(holiday);

        }

        public async Task<IEnumerable<HolidayListDto>> GetAllHoliday()
        {
            _logger.LogInformation("GetAllHoliday service started");
                var holidaylist = await _unitOfWork.HolidayListRepository.GetAll().ToListAsync();
            _logger.LogInformation("GetAllHoliday service ended");
            return _mapper.Map<IEnumerable<HolidayListDto>>(holidaylist);
        }

        public async Task<HolidayListDto> GetHolidayById(int Serial)
        {
            _logger.LogInformation("GetHolidayById service started");
            var holidaylist = await _unitOfWork.HolidayListRepository.Get(x => x.Serial == Serial).FirstOrDefaultAsync();
            _logger.LogInformation("GetHolidayById service ended");
            return _mapper.Map<HolidayListDto>(holidaylist);

            
        }

        public async  Task<HolidayListDto> UpdateHoliday(HolidayListDto holidayListDto)
        {
            _logger.LogInformation("UpdateHoliday service started");
                var holidaylist = await _unitOfWork.HolidayListRepository.Get(x => x.Serial == holidayListDto.Serial).FirstOrDefaultAsync();
            if(holidaylist != null)
            {
                var HolidayList = await _unitOfWork.HolidayListRepository.Update(_mapper.Map<HolidayList>(holidayListDto));
                return _mapper.Map<HolidayListDto>(HolidayList);
            }
            _logger.LogInformation("UpdateHoliday service ended");
            return _mapper.Map<HolidayListDto>(holidaylist);
        }
    }
}
