using HRMS.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Services.IServices
{
   public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllClients();
        Task<ClientDto> GetClientById(int id);
        Task<ClientDto> CreateClient(ClientDto clientDto);
        Task<ClientDto> UpdateClient(ClientDto clientDto);
        Task<ClientDto> DeleteClientById(int id);
    }
}
