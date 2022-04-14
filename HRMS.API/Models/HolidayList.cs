using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Models
{
    public class HolidayList
    {
        [Key]
        public int Serial { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(20)]
        public string HolidayType { get; set; }
    }
}
