using HRMS.API.Dtos;
using HRMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Repositories.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> Create(Employee employeeDto);
        Task<Employee> Update(Employee employeeDto);
        Task<Employee> Delete(int id);
    }
}
