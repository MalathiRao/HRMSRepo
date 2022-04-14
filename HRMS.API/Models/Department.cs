using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        [Required]
        public int Code { get; set; }
        [Required]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
