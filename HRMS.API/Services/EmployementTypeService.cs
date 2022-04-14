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


    public class EmployementTypeService : IEmployementTypeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployementTypeService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public EmployementTypeService(IUnitOfWork unitOfWork, ILogger<EmployementTypeService> logger, IConfiguration configuration, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._configuration = configuration;
            this._mapper = mapper;
        }

       
        public  async Task<IEnumerable<EmployementTypesDto>> GetAllEmployementType()
        {
            _logger.LogInformation("GetAllEmployementType service started");
            var emplType = await _unitOfWork.EmployementTypesRepository.GetAll().ToListAsync();
            _logger.LogInformation("GetAllEmployementType service ended");
            return _mapper.Map<IEnumerable<EmployementTypesDto>>(emplType);
        }

        public async Task<EmployementTypesDto> GetEmployementTypeById(int id)
        {
            _logger.LogInformation("EmployementTypesDto service started");
            var emplType = await _unitOfWork.EmployementTypesRepository.Get(x => x.EmpTypeID == id).FirstOrDefaultAsync();
            _logger.LogInformation("EmployementTypesDto service ended");
            return _mapper.Map<EmployementTypesDto>(emplType);
        }

        public async Task<EmployementTypesDto> CreateEmployementType(EmployementTypesDto employementTypesDto)
        {
            _logger.LogInformation("CreateEmployee service started");
            var result = await _unitOfWork.EmployementTypesRepository.InsertAsync(_mapper.Map<EmployementTypes>(employementTypesDto));
            _logger.LogInformation("CreateEmployee service ended");
            return _mapper.Map<EmployementTypesDto>(result);
        }

        public async Task<EmployementTypesDto> UpdateEmployementType(EmployementTypesDto employementTypesDto)
        {
            _logger.LogInformation("UpdateEmployementType service started");
            var emplType = await _unitOfWork.EmployementTypesRepository.Get(x => x.EmpTypeID == employementTypesDto.EmpTypeID).FirstOrDefaultAsync();
            if (emplType != null)
            {
                var emplymnt = await _unitOfWork.EmployementTypesRepository.Update(_mapper.Map<EmployementTypes>(employementTypesDto));
                return _mapper.Map<EmployementTypesDto>(emplymnt);
            }
            _logger.LogInformation("UpdateEmployementType service ended");
            return _mapper.Map<EmployementTypesDto>(emplType);
        }

        public async Task<EmployementTypesDto> DeleteEmployementTypeById(int id)
        {
           
                _logger.LogInformation("DeleteEmployementTypeById service started");
                var emplType = await _unitOfWork.EmployementTypesRepository.Get(x => x.EmpTypeID == id).FirstOrDefaultAsync();
                if (emplType == null)
                {
                    return _mapper.Map<EmployementTypesDto>(emplType);
                }
                await _unitOfWork.EmployementTypesRepository.DeleteAsync(emplType);
                _logger.LogInformation("DeleteEmployementTypeById service ended");
                return _mapper.Map<EmployementTypesDto>(emplType);
            
        }
    }
}
