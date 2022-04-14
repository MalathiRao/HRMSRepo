using HRMS.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Services.IServices
{
   public interface IEmployeeProjectService
    {
        Task<IEnumerable<EmployeeProjectsDto>> GetAllEmployeeProjects();
        Task<EmployeeProjectsDto> GetEmployeeProjectsById(int id);
        Task<EmployeeProjectsDto> CreateEmployeeProjects(EmployeeProjectsDto employeeProjectsDto);
        Task<EmployeeProjectsDto> UpdateEmployeeProjects(EmployeeProjectsDto employeeProjectsDto);
        Task<EmployeeProjectsDto> DeleteEmployeeProjectsById(int id);
    }
}
