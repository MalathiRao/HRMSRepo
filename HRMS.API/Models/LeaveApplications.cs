using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Models
{
    public class LeaveApplications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveAppID { get; set; }
        [Required]
        
        public int EmpID { get; set; }
        [ForeignKey("EmpID")]
        public virtual Employee Employee { get; set; }

       


        [Required]
        //[StringLength(7), Required]
        //[StringLength(100,MinimumLength =10)]
        //[StringLength(8, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int NoOfDays { get; set; }

        [Required]
        public int LeaveTypeID { get; set; }
        [ForeignKey("LeaveTypeID")]
        public virtual LeaveTypes LeaveTypes { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int CreatedById { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
        [Required]
        public int LastModifiedByID { get; set; }
    }
}
