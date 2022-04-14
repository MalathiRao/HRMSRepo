using HRMS.API.Models;
using HRMS.API.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; }
        private Dictionary<string, dynamic> _repositories;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.Context = dbContext;
        }

        private IBaseRepository<Employee> _EmployeeRepository;
        private IBaseRepository<Projects> _ProjectsRepository;
        private IBaseRepository<EmployeeProjects> _EmployeeProjectsRepository;
        private IBaseRepository<EmployementTypes> _EmployementTypesRepository;
        private IBaseRepository<ContactDetails> _ContactDetailsRepository;
        private IBaseRepository<HolidayList> _HolidayListRepository;
        private IBaseRepository<Department> _DepartmentsRepository;
        private IBaseRepository<Designation> _DesignationRepository;

        public IBaseRepository<Employee> EmployeeRepository
        {
            get { return _EmployeeRepository ?? (_EmployeeRepository = new BaseRepository<Employee>(this)); }
        }

        private IBaseRepository<Client> _ClientRepository;

        public IBaseRepository<Client> ClientRepository
        {
            get { return _ClientRepository ?? (_ClientRepository = new BaseRepository<Client>(this)); }
        }


        public IBaseRepository<Projects> ProjectsRepository
        {
            get { return _ProjectsRepository ?? (_ProjectsRepository = new BaseRepository<Projects>(this)); }
        }

        public IBaseRepository<EmployeeProjects> EmployeeProjectsRepository
        {
            get { return _EmployeeProjectsRepository ?? (_EmployeeProjectsRepository = new BaseRepository<EmployeeProjects>(this)); }
        }

        public IBaseRepository<EmployementTypes> EmployementTypesRepository
        {
            get { return _EmployementTypesRepository ?? (_EmployementTypesRepository = new BaseRepository<EmployementTypes>(this)); }
        }
       

        public IBaseRepository<ContactDetails> ContactDetailsRepository
        {
            get { return _ContactDetailsRepository ?? (_ContactDetailsRepository = new BaseRepository<ContactDetails>(this)); }
        }


        public IBaseRepository<HolidayList> HolidayListRepository
        {
            get { return _HolidayListRepository ?? (_HolidayListRepository = new BaseRepository<HolidayList>(this)); }
        }
        public IBaseRepository<Department> DepartmentsRepository
        {
            get { return _DepartmentsRepository ?? (_DepartmentsRepository = new BaseRepository<Department>(this)); }
        }

        public IBaseRepository<Designation> DesignationRepository
        {
            get { return _DesignationRepository ?? (_DesignationRepository = new BaseRepository<Designation>(this)); }
        }

        private IBaseRepository<LeaveTypes> _LeaveTypesRepository;

        public IBaseRepository<LeaveTypes> LeaveTypesRepository
        {
            get { return _LeaveTypesRepository ?? (_LeaveTypesRepository = new BaseRepository<LeaveTypes>(this)); }
        }
        private IBaseRepository<LeaveApplications> _LeaveApplicationsRepository;

        public IBaseRepository<LeaveApplications> LeaveApplicationsRepository
        {
            get { return _LeaveApplicationsRepository ?? (_LeaveApplicationsRepository = new BaseRepository<LeaveApplications>(this)); }
        }
        private IBaseRepository<LeaveBalance> _LeaveBalanceRepository;

        public IBaseRepository<LeaveBalance> LeaveBalanceRepository
        {
            get { return _LeaveBalanceRepository ?? (_LeaveBalanceRepository = new BaseRepository<LeaveBalance>(this)); }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                }
            }
        }


        public IBaseRepository<T> BaseRepository<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public IBaseRepository<T> RepositoryAsync<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }

            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type))
            {
                return (IBaseRepository<T>)_repositories[type];
            }


            var repositoryType = typeof(BaseRepository<>).MakeGenericType(typeof(T));

            _repositories.Add(type, Activator.CreateInstance(repositoryType, Context, this));

            return _repositories[type];
        }
    }
}
