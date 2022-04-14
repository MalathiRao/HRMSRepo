using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Models
{
    public class Employee
    {
        [Key]

        public int EmpID { get; set; }
        [Required]

        public string EmpCode { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string EmailID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }
        [Required]
        public int DeptID { get; set; }
        [ForeignKey("DeptID")]
        public virtual Department Department { get; set; }
        [Required]
        
        public int DesignationID { get; set; }
        [ForeignKey("DesignationID")]
        public virtual Designation Designation { get; set; }

        
        [Required]
        public int EmpTypeID { get; set; }
        [ForeignKey("EmpTypeID")]
        public virtual EmployementTypes EmployementTypes { get; set; }

        public int RepPersonEmpID { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int CreatedByID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }
        [Required]
        public int LastModifiedByID { get; set; }
    }
}
