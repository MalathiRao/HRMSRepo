using HRMS.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Services.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<EmployeeDto> CreateEmployee(EmployeeDto employeeDto);
        Task<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto);
        Task<EmployeeDto> DeleteEmployeeById(int id);
    }
}
