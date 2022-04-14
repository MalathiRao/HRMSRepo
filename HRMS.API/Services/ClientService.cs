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
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ClientService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ClientService(IUnitOfWork unitOfWork, ILogger<ClientService> logger, IConfiguration configuration, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._configuration = configuration;
            this._mapper = mapper;
        }
        public async Task<ClientDto> CreateClient(ClientDto clientDto)
        {
            _logger.LogInformation("CreateClient service started");
            var result = await _unitOfWork.ClientRepository.InsertAsync(_mapper.Map<Client>(clientDto));
            _logger.LogInformation("CreateClient service ended");
            return _mapper.Map<ClientDto>(result);
        }
        public async Task<ClientDto> GetClientById(int id)
        {
            _logger.LogInformation("GetClientById service started");
            var cnt = await _unitOfWork.ClientRepository.Get(c => c.ClientId == id).FirstOrDefaultAsync();
            _logger.LogInformation("GetClientById service ended");
            return _mapper.Map<ClientDto>(cnt);
        }
        
        
        public async Task<ClientDto> DeleteClientById(int id)
        {
            _logger.LogInformation("DeleteClientById service started");
            var Dlclnt = await _unitOfWork.ClientRepository.Get(x => x.ClientId== id).FirstOrDefaultAsync();
            if (Dlclnt == null)
            {
                return _mapper.Map<ClientDto>(Dlclnt);
            }
            await _unitOfWork.ClientRepository.DeleteAsync(Dlclnt);
            _logger.LogInformation("DeleteClientById service ended");
            return _mapper.Map<ClientDto>(Dlclnt);
        }

        public async Task<ClientDto> UpdateClient(ClientDto clientDto)
        {
            _logger.LogInformation("UpdateClient service started");
            var upclnt = await _unitOfWork.ClientRepository.Get(x => x.ClientId == clientDto.ClientId).FirstOrDefaultAsync();
            if (upclnt != null)
            {
                var client = await _unitOfWork.ClientRepository.Update(_mapper.Map<Client>(clientDto));
                return _mapper.Map<ClientDto>(client);
            }
            _logger.LogInformation("UpdateClient service ended");
            return _mapper.Map<ClientDto>(upclnt);
        }

        public  async Task<IEnumerable<ClientDto>> GetAllClients()
        {
            _logger.LogInformation("GetAllClients service started");
            var clientlist = await _unitOfWork.ClientRepository.GetAll().ToListAsync();
            _logger.LogInformation("GetAllEClients service ended");
            return _mapper.Map<IEnumerable<ClientDto>>(clientlist);
        }
    }
}
