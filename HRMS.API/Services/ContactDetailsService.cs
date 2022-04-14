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
    public class ContactDetailsService : IContactDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ContactDetailsService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ContactDetailsService(IUnitOfWork unitOfWork, ILogger<ContactDetailsService> logger, IConfiguration configuration, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._configuration = configuration;
            this._mapper = mapper;
        }
        public async Task<ContactDetailsDto> CreateContactDetails(ContactDetailsDto contactDetailsDto)
        {
            _logger.LogInformation("CreateContactDetails service started");
            var result = await _unitOfWork.ContactDetailsRepository.InsertAsync(_mapper.Map<ContactDetails>(contactDetailsDto));
            _logger.LogInformation("CreateContactDetails service ended");
            return _mapper.Map<ContactDetailsDto>(result);
        }

        //public Task<ContactDetailsDto> CreateContactDetails(ContactDetailsDto contactdetailsDto)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ContactDetailsDto> DeleteContactDetailsById(int id)
        {
            _logger.LogInformation("DeleteContactDetailsById service started");
            var CDetails = await _unitOfWork.ContactDetailsRepository.Get(x => x.ContactID == id).FirstOrDefaultAsync();
            if (CDetails == null)
            {
                return _mapper.Map<ContactDetailsDto>(CDetails);
            }
            await _unitOfWork.ContactDetailsRepository.DeleteAsync(CDetails);
            _logger.LogInformation("DeleteContactDetailsById service ended");
            return _mapper.Map<ContactDetailsDto>(CDetails);
        }

        public async Task<IEnumerable<ContactDetailsDto>> GetAllContactDetails()
        {
            _logger.LogInformation("GetAllContactDetails service started");
            var CDlist = await _unitOfWork.ContactDetailsRepository.GetAll().ToListAsync();
            _logger.LogInformation("GetAllContactDetails service ended");
            return _mapper.Map<IEnumerable<ContactDetailsDto>>(CDlist);
        }

        public async Task<ContactDetailsDto> GetContactDetailsById(int id)
        {
            _logger.LogInformation("GetContactDetailsById service started");
            var CDbyID = await _unitOfWork.ContactDetailsRepository.Get(x => x.ContactID == id).FirstOrDefaultAsync();
            _logger.LogInformation("GetContactDetailsById service ended");
            return _mapper.Map<ContactDetailsDto>(CDbyID);
        }

        public async Task<ContactDetailsDto> UpdateContactDetails(ContactDetailsDto contactDetailsDto)
        {
            _logger.LogInformation("UpdateContactDetails service started");
            var UCDetails = await _unitOfWork.ContactDetailsRepository.Get(x => x.EmpID == contactDetailsDto.ContactID).FirstOrDefaultAsync();
            if (UCDetails != null)
            {
                var Contactdetails = await _unitOfWork.ContactDetailsRepository.Update(_mapper.Map<ContactDetails>(contactDetailsDto));
                return _mapper.Map<ContactDetailsDto>(Contactdetails);
            }
            _logger.LogInformation("UpdateContactDetails service ended");
            return _mapper.Map<ContactDetailsDto>(UCDetails);
        }
    }

}
