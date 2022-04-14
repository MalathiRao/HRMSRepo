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
    public class DesignationService : IDesignationService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DesignationService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public DesignationService(IUnitOfWork unitOfWork, ILogger<DesignationService> logger, IConfiguration configuration, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._configuration = configuration;
            this._mapper = mapper;
        }

        public async Task<DesignationDto> CreateDesignation(DesignationDto designationDto)
        {
            _logger.LogInformation("Create Designation service started");
            var result = await _unitOfWork.DesignationRepository.InsertAsync(_mapper.Map<Designation>(designationDto));
            _logger.LogInformation("Create Designation service ended");
            return _mapper.Map<DesignationDto>(result);
        }

        public async Task<DesignationDto> DeleteDesignationById(int DesignationID)
        {
            _logger.LogInformation("DeleteDesignationById service started");
            var result = await _unitOfWork.DesignationRepository.Get(x => x.DesignationID == DesignationID).FirstOrDefaultAsync();
            if(result==null)
            {
               return _mapper.Map<DesignationDto>(result);
            }
            await _unitOfWork.DesignationRepository.DeleteAsync(result);
            _logger.LogInformation("DeleteDesignationById service ended");
           return _mapper.Map<DesignationDto>(result);
        }

        public async Task<IEnumerable<DesignationDto>> GetAllDesignation()
        {
            _logger.LogInformation("GetAllDesignationt service started");
            var result = await _unitOfWork.DesignationRepository.GetAll().ToListAsync();
            _logger.LogInformation("GetAllDesignation service ended");
            return _mapper.Map<IEnumerable<DesignationDto>>(result);
        }

        public async Task<DesignationDto> GetDesignationById(int DesignationID)
        {
            _logger.LogInformation("GetDesignationById service started");
            var result = await _unitOfWork.DesignationRepository.Get(x => x.DesignationID == DesignationID).FirstOrDefaultAsync();
            _logger.LogInformation("GetDesignationById service ended");
            return _mapper.Map<DesignationDto>(result);
        }

        public async Task<DesignationDto> UpdateDesignation(DesignationDto designationDto)
        {
            _logger.LogInformation("UpdateDesignation service started");
            var result = await _unitOfWork.DesignationRepository.Get(X => X.DesignationID == designationDto.DesignationID).FirstOrDefaultAsync();
            if(result!=null)
            {
                var response = await _unitOfWork.DesignationRepository.Update(_mapper.Map<Designation>(designationDto));
                _logger.LogInformation("UpdateDesignation service ended");
                return _mapper.Map<DesignationDto>(response);
            }
            return _mapper.Map<DesignationDto>(result);
        }
    }
}
