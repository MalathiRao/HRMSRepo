using HRMS.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Services.IServices
{
    public interface IHolidayService
    {
        Task<IEnumerable<HolidayListDto>> GetAllHoliday();
        Task<HolidayListDto> GetHolidayById(int Serial);
        Task<HolidayListDto> CreateHoliday(HolidayListDto holidayListDto);
        Task<HolidayListDto> UpdateHoliday(HolidayListDto holidayListDto);
        Task<HolidayListDto> DeleteHolidayById(int Serial);
    }
}
