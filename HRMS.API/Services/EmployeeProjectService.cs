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
    public class EmployeeProjectService : IEmployeeProjectService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployeeProjectService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public EmployeeProjectService(IUnitOfWork unitOfWork, ILogger<EmployeeProjectService> logger, IConfiguration configuration, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._configuration = configuration;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeProjectsDto>> GetAllEmployeeProjects()
        {
            _logger.LogInformation("GetAllEmployeeProjects service started");
            var empPrjctlist = await _unitOfWork.EmployeeProjectsRepository.GetAll().ToListAsync();
            _logger.LogInformation("GetAllEmployeeProjects service ended");
            return _mapper.Map<IEnumerable<EmployeeProjectsDto>>(empPrjctlist);
        }

        public async Task<EmployeeProjectsDto> GetEmployeeProjectsById(int id)
        {
            _logger.LogInformation("GetEmployeeProjectsById service started");
            var empPrjctlist = await _unitOfWork.EmployeeProjectsRepository.Get(x => x.Serial == id).FirstOrDefaultAsync();
            _logger.LogInformation("GetEmployeeProjectsById service ended");
            return _mapper.Map<EmployeeProjectsDto>(empPrjctlist);
        }

        public async Task<EmployeeProjectsDto> CreateEmployeeProjects(EmployeeProjectsDto employeeProjectsDto)
        {
            _logger.LogInformation("CreateEmployeeProjects service started");
            var result = await _unitOfWork.EmployeeProjectsRepository.InsertAsync(_mapper.Map<EmployeeProjects>(employeeProjectsDto));
            _logger.LogInformation("CreateEmployeeProjects service ended");
            return _mapper.Map<EmployeeProjectsDto>(result);
        }

       
        public async Task<EmployeeProjectsDto> UpdateEmployeeProjects(EmployeeProjectsDto employeeProjectsDto)
        {
            _logger.LogInformation("UpdateEmployeeProjects service started");
            var empPrjct = await _unitOfWork.EmployeeProjectsRepository.Get(x => x.Serial == employeeProjectsDto.Serial).FirstOrDefaultAsync();
            if (empPrjct != null)
            {
                var employeePrjct = await _unitOfWork.EmployeeProjectsRepository.Update(_mapper.Map<EmployeeProjects>(employeeProjectsDto));
                return _mapper.Map<EmployeeProjectsDto>(employeePrjct);
            }
            _logger.LogInformation("UpdateEmployeeProjects service ended");
            return _mapper.Map<EmployeeProjectsDto>(empPrjct);
        }

        public async Task<EmployeeProjectsDto> DeleteEmployeeProjectsById(int id)
        {
            _logger.LogInformation("DeleteEmployeeProjectsById service started");
            var empPrjct = await _unitOfWork.EmployeeProjectsRepository.Get(x => x.Serial == id).FirstOrDefaultAsync();
            if (empPrjct == null)
            {
                return _mapper.Map<EmployeeProjectsDto>(empPrjct);
            }
            await _unitOfWork.EmployeeProjectsRepository.DeleteAsync(empPrjct);
            _logger.LogInformation("DeleteEmployeeProjectsById service ended");
            return _mapper.Map<EmployeeProjectsDto>(empPrjct);
        }
    }
}
