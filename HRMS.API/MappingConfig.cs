using AutoMapper;
using HRMS.API.Dtos;
using HRMS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfig = new MapperConfiguration(config =>
             {
                 config.CreateMap<EmployeeDto, Employee>();
                 config.CreateMap<Employee, EmployeeDto>();

                 config.CreateMap<ClientDto, Client>();
                 config.CreateMap<Client, ClientDto>();

                 config.CreateMap<ContactDetailsDto, ContactDetails>();
                 config.CreateMap<ContactDetails, ContactDetailsDto>();

                 config.CreateMap<EmployementTypesDto, EmployementTypes>();
                 config.CreateMap<EmployementTypes, EmployementTypesDto>();

                 config.CreateMap<EmployeeProjects, EmployeeProjectsDto>();
                 config.CreateMap<EmployeeProjectsDto, EmployeeProjects>();

                 config.CreateMap<ProjectsDto, Projects>();
                 config.CreateMap<Projects, ProjectsDto>();

                 config.CreateMap<HolidayListDto, HolidayList>();
                 config.CreateMap<HolidayList, HolidayListDto>();
                 config.CreateMap<DepartmentDto, Department>();
                 config.CreateMap<Department, DepartmentDto>();
                 config.CreateMap<DesignationDto, Designation>();
                 config.CreateMap<Designation, DesignationDto>();

                 config.CreateMap<LeaveTypes, LeaveTypesDto>();
                 config.CreateMap<LeaveTypesDto, LeaveTypes>();
                 config.CreateMap<LeaveApplications, LeaveApplicationsDto>();
                 config.CreateMap<LeaveApplicationsDto, LeaveApplications>();
                 config.CreateMap<LeaveBalance, LeaveBalanceDto>();
                 config.CreateMap<LeaveBalanceDto, LeaveBalance>();
             });
            return mapperConfig;
        }
    }
}
