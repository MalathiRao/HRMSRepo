using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Dtos
{
    public class EmployeeDto
    {
        public int EmpID { get; set; }
        public string EmpCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public DateTime JoiningDate { get; set; }
        public int DeptID { get; set; }
        public int DesignationID { get; set; }
        public int EmpTypeID { get; set; }
        public int RepPersonEmpID { get; set; }
        public bool IsAdmin { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByID { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedByID { get; set; }
    }
}
