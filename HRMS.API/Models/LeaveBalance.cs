using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Models
{
    public class LeaveBalance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveBalanceID { get; set; }
        [Required]
        [ForeignKey("EmpID")]
        public int EmpID { get; set; }
        [Required]
        
        public int LeaveTypeID { get; set; }
        [ForeignKey("LeaveTypeID")]
        public virtual LeaveTypes LeaveTypes { get; set; }

        [Required]
        public float NoOfLeavesAllocated { get; set; }
        [Required]
        public float NoOfLeavesRemaining { get; set; }
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
