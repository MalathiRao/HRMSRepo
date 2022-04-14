using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HRMS.API.Models;

namespace HRMS.Web.Models
{
    public class Employee
    {        
        [Key]
        public int EmpID { get; set; }
        [Required]
        public string? EmpCode { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        public int DeptID { get; set; }
        public int DesignationID { get; set; }
        public int EmpTypeID { get; set; }
        public int RepPersonEmpID { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int CreatedByID { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
        [Required]
        public int LastModifiedByID { get; set; }
    }
}
