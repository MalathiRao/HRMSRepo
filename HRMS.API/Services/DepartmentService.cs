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

    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DepartmentService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public  DepartmentService(IUnitOfWork unitOfWork, ILogger<DepartmentService> logger, IConfiguration configuration, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._configuration = configuration;
            this._mapper = mapper;

        }
            

        public async Task<DepartmentDto> CreateDepartment(DepartmentDto departmentsDto)
        {
            _logger.LogInformation("CreateDepartment service started");
            var result = await _unitOfWork.DepartmentsRepository.InsertAsync(_mapper.Map <Department> (departmentsDto));
            _logger.LogInformation("CreateDepartment service ended");
            return _mapper.Map<DepartmentDto>(result);

        }

        public async Task<DepartmentDto> DeleteDepartmentById(int DeptID)
        {
            _logger.LogInformation("DeleteDepartmentById service started");
            var result = await _unitOfWork.DepartmentsRepository.Get(x => x.DeptId ==DeptID).FirstOrDefaultAsync();
            if (result == null)
            {
                return _mapper.Map<DepartmentDto>(result);
            }
            await _unitOfWork.DepartmentsRepository.DeleteAsync(result);
            _logger.LogInformation("DeleteDepartmentById service ended");
            return _mapper.Map<DepartmentDto>(result);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartments()
        {
            _logger.LogInformation("GetAllDepartment service started");
            var result = await _unitOfWork.DepartmentsRepository.GetAll().ToListAsync();
            _logger.LogInformation("GetAllDepartment service ended");
            return _mapper.Map<IEnumerable<DepartmentDto>>(result);
        }

        public async Task<DepartmentDto> GetDepartmentById(int DeptID)
        {
            _logger.LogInformation("GetDepartmentById service started");
            var result = await _unitOfWork.DepartmentsRepository.Get(x => x.DeptId == DeptID).FirstOrDefaultAsync();
            _logger.LogInformation("GetDepartmentByID service ended");
            return _mapper.Map<DepartmentDto>(result);
            
        }

        public async Task<DepartmentDto> UpdateDepartment(DepartmentDto departmentsDto)
        {
            _logger.LogInformation("UpdateDepartment service started");
            var result= await _unitOfWork.DepartmentsRepository.Get(x=>x.DeptId==departmentsDto.DeptID).FirstOrDefaultAsync();
            if (result != null)
            {
                var response = await _unitOfWork.DepartmentsRepository.Update(_mapper.Map<Department>(departmentsDto));
               return _mapper.Map<DepartmentDto>(response);

            }
            _logger.LogInformation("UpdateDepartment service ended");
           return _mapper.Map<DepartmentDto>(result);


        }
    }
}
