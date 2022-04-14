using HRMS.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Services.IServices
{
    public interface IContactDetailsService
    {
        Task<IEnumerable<ContactDetailsDto>> GetAllContactDetails();
        Task<ContactDetailsDto> GetContactDetailsById(int id);
        Task<ContactDetailsDto> CreateContactDetails(ContactDetailsDto contactdetailsDto);
        Task<ContactDetailsDto> UpdateContactDetails(ContactDetailsDto contactdetailsDto);
        Task<ContactDetailsDto> DeleteContactDetailsById(int id);
    }
}
