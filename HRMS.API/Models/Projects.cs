using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Models
{
    public class Projects
    {


        [Required]
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [Required]
        [StringLength(20)]
        public string ProjectCode { get; set; }
        [Required]
        [StringLength(50)]
        public string ProjectName { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [StringLength(50)]
        public String ClientName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(20)]
        public string Status { get; set; }


    }
}
