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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployeeService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork unitOfWork,ILogger<EmployeeService> logger,IConfiguration configuration,IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._configuration = configuration;
            this._mapper = mapper;
        }
        public async Task<EmployeeDto> CreateEmployee(EmployeeDto employeeDto)
        {
            _logger.LogInformation("CreateEmployee service started");
            var result = await _unitOfWork.EmployeeRepository.InsertAsync(_mapper.Map<Employee>(employeeDto));
            _logger.LogInformation("CreateEmployee service ended");
            return _mapper.Map<EmployeeDto>(result);
        }

        public async Task<EmployeeDto> DeleteEmployeeById(int id)
        {
            _logger.LogInformation("DeleteEmployeeById service started");
            var emp = await _unitOfWork.EmployeeRepository.Get(x => x.EmpID == id).FirstOrDefaultAsync();
            if(emp == null)
            {
                return _mapper.Map<EmployeeDto>(emp);
            }
            await _unitOfWork.EmployeeRepository.DeleteAsync(emp);
            _logger.LogInformation("DeleteEmployeeById service ended");
            return _mapper.Map<EmployeeDto>(emp);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            _logger.LogInformation("GetAllEmployees service started");
            var emplist = await _unitOfWork.EmployeeRepository.GetAll().ToListAsync();
            _logger.LogInformation("GetAllEmployees service ended");
            return _mapper.Map<IEnumerable<EmployeeDto>>(emplist);
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            _logger.LogInformation("GetEmployeeById service started");
            var emp = await _unitOfWork.EmployeeRepository.Get(x => x.EmpID == id).FirstOrDefaultAsync();
            _logger.LogInformation("GetEmployeeById service ended");
            return _mapper.Map<EmployeeDto>(emp);
        }

        public async Task<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto)
        {
            _logger.LogInformation("UpdateEmployee service started");
            var emp = await _unitOfWork.EmployeeRepository.Get(x => x.EmpID == employeeDto.EmpID).FirstOrDefaultAsync();
            if (emp != null)
            {
                var employee = await _unitOfWork.EmployeeRepository.Update(_mapper.Map<Employee>(employeeDto));
                return _mapper.Map<EmployeeDto>(employee);
            }
            _logger.LogInformation("UpdateEmployee service ended");
            return _mapper.Map<EmployeeDto>(emp);
        }
    }
}
