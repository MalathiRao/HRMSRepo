using HRMS.API.Models;
using HRMS.API.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Repositories.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        ApplicationDbContext Context { get; }
        IBaseRepository<T> BaseRepository<T>() where T : class;
        IBaseRepository<Employee> EmployeeRepository { get; }

        IBaseRepository<Client> ClientRepository { get; }

        IBaseRepository<Projects> ProjectsRepository { get; }
        IBaseRepository<EmployeeProjects> EmployeeProjectsRepository { get; }
        IBaseRepository<EmployementTypes> EmployementTypesRepository { get; }
        IBaseRepository<ContactDetails> ContactDetailsRepository { get; }

        IBaseRepository<HolidayList> HolidayListRepository { get; }
        IBaseRepository<Department> DepartmentsRepository { get; }
        IBaseRepository<Designation> DesignationRepository { get; }

        IBaseRepository<LeaveTypes> LeaveTypesRepository { get; }
        IBaseRepository<LeaveApplications> LeaveApplicationsRepository { get; }
        IBaseRepository<LeaveBalance> LeaveBalanceRepository { get; }

    }
}
