using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMS.Web.Models;

namespace HRMS.Web.Models
{
    public class EmployeeContact
    {

        public Employee Employeedetails{ get; set; }

        public ContactDetails Contactdetails { get; set; }

    }
}
