using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Models
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<EmployeeProjects> EmployeeProjects { get; set; }
        public DbSet<EmployementTypes> EmployementTypes { get; set; }
        public DbSet<Projects> Projects { get; set; }

        public DbSet<HolidayList> HolidayList { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LeaveApplications> LeaveApplications { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }
        public DbSet<LeaveTypes> LeaveTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Set NoKey to Contact Details
           
        }


    }
}
