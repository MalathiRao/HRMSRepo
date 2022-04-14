using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Models
{
    public class Designation
    {
        [Key]
        public int DesignationID { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
