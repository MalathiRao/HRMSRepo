using HRMS.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Services.IServices
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto> GetDepartmentById(int DeptID);
        Task<DepartmentDto> CreateDepartment(DepartmentDto departmentsDto);
        Task<DepartmentDto> UpdateDepartment(DepartmentDto departmentsDto);
        Task<DepartmentDto> DeleteDepartmentById(int DeptID);
    }
}
