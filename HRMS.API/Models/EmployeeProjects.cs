using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.API.Models
{
    public class EmployeeProjects
    {
        [Key]
        public int Serial { get; set; }
        
        [Required]
        public int EmpID { get; set; }
        [ForeignKey("EmpID")]
        public virtual Employee Employee { get; set; }

        [Required]        
        public int ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Projects Projects { get; set; }

    }
}
