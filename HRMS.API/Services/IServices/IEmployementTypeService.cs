using HRMS.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Services.IServices
{
    public interface IEmployementTypeService
    {
        Task<IEnumerable<EmployementTypesDto>> GetAllEmployementType();
        Task<EmployementTypesDto> GetEmployementTypeById(int id);
        Task<EmployementTypesDto> CreateEmployementType(EmployementTypesDto employementTypesDto);
        Task<EmployementTypesDto> UpdateEmployementType(EmployementTypesDto employementTypesDto);
        Task<EmployementTypesDto> DeleteEmployementTypeById(int id);
    }
}
