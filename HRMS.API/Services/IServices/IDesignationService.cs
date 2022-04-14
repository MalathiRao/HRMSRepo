using HRMS.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Services.IServices
{
    public interface IDesignationService
    {
        Task<IEnumerable<DesignationDto>> GetAllDesignation();
        Task<DesignationDto> GetDesignationById(int DesignationID);
        Task<DesignationDto> CreateDesignation(DesignationDto designationDto);
        Task<DesignationDto> UpdateDesignation(DesignationDto designationDto);
        Task<DesignationDto> DeleteDesignationById(int DesignationID);
    }
}
