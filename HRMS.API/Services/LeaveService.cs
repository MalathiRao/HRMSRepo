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
    public class LeaveService : ILeaveService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LeaveService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public LeaveService(IUnitOfWork unitOfWork, ILogger<LeaveService> logger, IConfiguration configuration, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._configuration = configuration;
            this._mapper = mapper;
        }
        //LeaveTypes

        //GetAll
        public async Task<IEnumerable<LeaveTypesDto>> GetAllLeaveTypes()
        {
            _logger.LogInformation("GetAllLeaveTypes service started");
            var listLeaves = await _unitOfWork.LeaveTypesRepository.GetAll().ToListAsync();
            _logger.LogInformation("GetAllLeaveTypes service ended");
            return _mapper.Map<IEnumerable<LeaveTypesDto>>(listLeaves);
        }
        //GetAllBYId
        public async Task<LeaveTypesDto> GetAllLeaveTypesByID(int id)
        {
            _logger.LogInformation("GetAllLeaveTypesByID service started");
            var leaveId = await _unitOfWork.LeaveTypesRepository.Get(x => x.LeaveTypeID == id).FirstOrDefaultAsync();
            _logger.LogInformation("GetAllLeaveTypesByID service ended");
            return _mapper.Map<LeaveTypesDto>(leaveId);
        }
        //CreateLeaveTypesId
        public async Task<LeaveTypesDto> CreateAllLeaveTypesId(LeaveTypesDto leaveTypesDto)
        {
            _logger.LogInformation("CreateAllLeaveTypesId service started");
            var result = await _unitOfWork.LeaveTypesRepository.InsertAsync(_mapper.Map<LeaveTypes>(leaveTypesDto));
            _logger.LogInformation("CreateAllLeaveTypesId service ended");
            return _mapper.Map<LeaveTypesDto>(result);
        }
        //EditLeaveTypesId
        public async Task<LeaveTypesDto> UpdateAllLeaveTypesId(LeaveTypesDto leaveTypesDto)
        {
            _logger.LogInformation("UpdateAllLeaveTypesId service started");
            var updateLeave = await _unitOfWork.LeaveTypesRepository.Get(x => x.LeaveTypeID == leaveTypesDto.LeaveTypeID).FirstOrDefaultAsync();
            if (updateLeave != null)
            {
                var employeeLeave = await _unitOfWork.LeaveTypesRepository.Update(_mapper.Map<LeaveTypes>(leaveTypesDto));
                return _mapper.Map<LeaveTypesDto>(employeeLeave);
            }
            _logger.LogInformation("UpdateAllLeaveTypesId service ended");
            return _mapper.Map<LeaveTypesDto>(updateLeave);
        }
        //DeleteLeaveTypedId
        public async Task<LeaveTypesDto> DeleteAllLeaveTypesId(int id)
        {
            _logger.LogInformation("DeleteAllLeaveTypesId service started");
            var leaveDelete = await _unitOfWork.LeaveTypesRepository.Get(e => e.LeaveTypeID == id).FirstOrDefaultAsync();
            if (leaveDelete == null)
            {
                return _mapper.Map<LeaveTypesDto>(leaveDelete);
            }
            await _unitOfWork.LeaveTypesRepository.DeleteAsync(leaveDelete);
            _logger.LogInformation("DeleteAllLeaveTypesId service ended");
            return _mapper.Map<LeaveTypesDto>(leaveDelete);
        }
        public async Task<LeaveTypesDto> Gettype(LeaveTypesDto leaveTypesDto)
        {
            _logger.LogInformation("GetType Service started");
            var getType = await _unitOfWork.LeaveTypesRepository.FindAsync();
            _logger.LogInformation("GetAllLeaveTypesByID service ended");
            return _mapper.Map<LeaveTypesDto>(getType);
        }


        //LeaveApllications
        //GetAll
        public async Task<IEnumerable<LeaveApplicationsDto>> GetAllLeaves()
        {
            _logger.LogInformation("GetAllLeaves service started");
            var empAllLeaves = await _unitOfWork.LeaveApplicationsRepository.GetAll().ToListAsync();
            _logger.LogInformation("GetAllLeaves service ended");
            return _mapper.Map<IEnumerable<LeaveApplicationsDto>>(empAllLeaves);
        }
        //GetEmployessById
        public async Task<LeaveApplicationsDto> GetEmployeeLeavesById(int id)
        {
            _logger.LogInformation("GetAllLeaveTypesByID service started");
            var leaveId = await _unitOfWork.LeaveApplicationsRepository.Get(x => x.LeaveAppID == id).FirstOrDefaultAsync();
            _logger.LogInformation("GetAllLeaveTypesByID service ended");
            return _mapper.Map<LeaveApplicationsDto>(leaveId);
        }

        //CreateLeaves
        public async Task<LeaveApplicationsDto> CreateEmployeeLeaves(LeaveApplicationsDto leaveApplicationsDto)
        {
            _logger.LogInformation("CreateEmployeeLeaves service started");
            var result = await _unitOfWork.LeaveApplicationsRepository.InsertAsync(_mapper.Map<LeaveApplications>(leaveApplicationsDto));
            _logger.LogInformation("CreateEmployeeLeaves service ended");
            return _mapper.Map<LeaveApplicationsDto>(result);
        }

        //UpdateLeaves
        public async Task<LeaveApplicationsDto> UpdateEmployeeLeaves(LeaveApplicationsDto leaveApplicationsDto)
        {
            _logger.LogInformation("UpdateEmployeeLeaves service started");
            var updateLeave = await _unitOfWork.LeaveApplicationsRepository.Get(x => x.LeaveAppID == leaveApplicationsDto.LeaveAppId).FirstOrDefaultAsync();
            if (updateLeave != null)
            {
                var employeeUpdateLeave = await _unitOfWork.LeaveApplicationsRepository.Update(_mapper.Map<LeaveApplications>(leaveApplicationsDto));
                return _mapper.Map<LeaveApplicationsDto>(employeeUpdateLeave);
            }
            _logger.LogInformation("UpdateEmployeeLeaves service ended");
            return _mapper.Map<LeaveApplicationsDto>(updateLeave);
        }

        //DeleteLeaves
        public async Task<LeaveApplicationsDto> DeleteEmployeeLeavesById(int id)
        {
            _logger.LogInformation("DeleteAllLeaveTypesId service started");
            var leaveDelete = await _unitOfWork.LeaveApplicationsRepository.Get(e => e.LeaveAppID == id).FirstOrDefaultAsync();
            if (leaveDelete == null)
            {
                return _mapper.Map<LeaveApplicationsDto>(leaveDelete);
            }
            await _unitOfWork.LeaveApplicationsRepository.DeleteAsync(leaveDelete);
            _logger.LogInformation("DeleteAllLeaveTypesId service ended");
            return _mapper.Map<LeaveApplicationsDto>(leaveDelete);
        }


        //Leave Balance
        //GetAllBalance
        public async Task<IEnumerable<LeaveBalanceDto>> GetAllLeaveBalance()
        {
            _logger.LogInformation("GetAllLeaveBalance service started");
            var empAllBalances = await _unitOfWork.LeaveBalanceRepository.GetAll().ToListAsync();
            _logger.LogInformation("GetAllLeaveBalance service ended");
            return _mapper.Map<IEnumerable<LeaveBalanceDto>>(empAllBalances);
        }
        //GetAllBalancebyID
        public async Task<LeaveBalanceDto> GetAllLeaveBalanceById(int id)
        {
            _logger.LogInformation("GetAllLeaveTypesByID service started");
            var leaveId = await _unitOfWork.LeaveBalanceRepository.Get(x => x.LeaveBalanceID == id).FirstOrDefaultAsync();
            _logger.LogInformation("GetAllLeaveTypesByID service ended");
            return _mapper.Map<LeaveBalanceDto>(leaveId);
        }

        //CreateLeaveBalance
        public async Task<LeaveBalanceDto> CreateLeaveBalance(LeaveBalanceDto leaveBalanceDto)
        {
            _logger.LogInformation("CreateLeaveBalance service started");
            var createLeave = await _unitOfWork.LeaveBalanceRepository.InsertAsync(_mapper.Map<LeaveBalance>(leaveBalanceDto));
            _logger.LogInformation("CreateLeaveBalance service ended");
            return _mapper.Map<LeaveBalanceDto>(createLeave);
        }

        //UpdateLeaveBalance
        public async Task<LeaveBalanceDto> UpdateLeaveBalance(LeaveBalanceDto leaveBalanceDto)
        {
            _logger.LogInformation("UpdateLeaveBalance service started");
            var updateLeave = await _unitOfWork.LeaveBalanceRepository.Get(x => x.LeaveBalanceID == leaveBalanceDto.LeaveBalanceID).FirstOrDefaultAsync();
            if (updateLeave != null)
            {
                var employeeUpdateLeave = await _unitOfWork.LeaveBalanceRepository.Update(_mapper.Map<LeaveBalance>(leaveBalanceDto));
                return _mapper.Map<LeaveBalanceDto>(employeeUpdateLeave);
            }
            _logger.LogInformation("UpdateLeaveBalance service ended");
            return _mapper.Map<LeaveBalanceDto>(updateLeave);
        }
        //DeleteLeaveBalance
        public async Task<LeaveBalanceDto> DeleteLeaveBalance(int id)
        {
            _logger.LogInformation("DeleteLeaveBalance service started");
            var leaveDelete = await _unitOfWork.LeaveBalanceRepository.Get(e => e.LeaveBalanceID == id).FirstOrDefaultAsync();
            if (leaveDelete == null)
            {
                return _mapper.Map<LeaveBalanceDto>(leaveDelete);
            }
            await _unitOfWork.LeaveBalanceRepository.DeleteAsync(leaveDelete);
            _logger.LogInformation("DeleteLeaveBalance service ended");
            return _mapper.Map<LeaveBalanceDto>(leaveDelete);
        }


    }
}
