using HRMS.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Services.IServices
{
    public interface ILeaveService
    {
        //Leave Types
        Task<IEnumerable<LeaveTypesDto>> GetAllLeaveTypes();
        Task<LeaveTypesDto> GetAllLeaveTypesByID(int id);
        Task<LeaveTypesDto> Gettype(LeaveTypesDto leaveTypesDto);
        Task<LeaveTypesDto> CreateAllLeaveTypesId(LeaveTypesDto leaveTypesDto);
        Task<LeaveTypesDto> UpdateAllLeaveTypesId(LeaveTypesDto leaveTypesDto);
        Task<LeaveTypesDto> DeleteAllLeaveTypesId(int id);


        //Leave Applications
        Task<IEnumerable<LeaveApplicationsDto>> GetAllLeaves();
        Task<LeaveApplicationsDto> GetEmployeeLeavesById(int id);
        Task<LeaveApplicationsDto> CreateEmployeeLeaves(LeaveApplicationsDto leaveApplicationsDto);
        Task<LeaveApplicationsDto> UpdateEmployeeLeaves(LeaveApplicationsDto leaveApplicationsDto);
        Task<LeaveApplicationsDto> DeleteEmployeeLeavesById(int id);


        //Leave Balance

        Task<IEnumerable<LeaveBalanceDto>> GetAllLeaveBalance();
        Task<LeaveBalanceDto> GetAllLeaveBalanceById(int Id);
        Task<LeaveBalanceDto> CreateLeaveBalance(LeaveBalanceDto leaveBalanceDto);
        Task<LeaveBalanceDto> UpdateLeaveBalance(LeaveBalanceDto leaveBalanceDto);
        Task<LeaveBalanceDto> DeleteLeaveBalance(int id);
    }
}
