using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Models
{
    public class LeaveTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
    }
}
