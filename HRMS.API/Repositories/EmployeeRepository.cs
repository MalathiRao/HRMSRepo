using HRMS.API.Dtos;
using HRMS.API.Models;
using HRMS.API.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<Employee> Create(Employee employeeDto)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Update(Employee employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
