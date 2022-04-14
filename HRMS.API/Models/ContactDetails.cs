using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Models
{
    
    public class ContactDetails
    {
        [Key]
        public int ContactID { get; set; }
      
        [Required]
        public int EmpID { get; set; }
        [ForeignKey("EmpID")]
        public virtual Employee Employee { get; set; }

        [Required]
        [StringLength(100)]
        public string PersonalEmailID { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [Required]
        [StringLength(10)]
        public string BloodGroup { get; set; }
        [Required]
        [StringLength(15)]
        public long MobileNo { get; set; }
        [Required]
        [StringLength(100)]
        public string EmgContactPersonName { get; set; }
        [Required]

        public long EmgContactMobileNo { get; set; }
        [Required]
        [StringLength(100)]
        public String PhotoFileName { get; set; }
        [Required]
        [StringLength(10)]
        public string PanNo { get; set; }
        [Required]
        [StringLength(12)]
        public long AadharNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string PrestAddr_HNo { get; set; }
        [Required]
        [StringLength(200)]
        public string PrestAddr_Street { get; set; }
        [Required]
        [StringLength(50)]
        public string PrestAddr_City { get; set; }
        [Required]
        [StringLength(50)]
        public string PrestAddr_State { get; set; }
        [Required]
        [StringLength(25)]
        public string PrestAddr_Country { get; set; }
        [Required]
        [StringLength(20)]
        public string PermAddr_HNo { get; set; }
        [Required]
        [StringLength(200)]
        public string PermAddr_Street { get; set; }
        [Required]
        [StringLength(50)]
        public string PermAddr_City { get; set; }
        [Required]
        [StringLength(25)]
        public string PermAddr_State { get; set; }
        [Required]
        [StringLength(25)]
        public string PermAddr_Country { get; set; }
    }
}
