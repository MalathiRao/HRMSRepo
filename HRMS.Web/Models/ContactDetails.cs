using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Web.Models
{
    public class ContactDetails
    {
      
            [Key]
            public int ContactID { get; set; }
            [ForeignKey("EmpID")]
            public int EmpID { get; set; }
            public string PersonalEmailID { get; set; }
            public DateTime DOB { get; set; }
            public string Gender { get; set; }
            public string BloodGroup { get; set; }
            public int MobileNo { get; set; }
            public string EmgContactPersonName { get; set; }
            public int EmgContactMobileNo { get; set; }

            public String PhotoFileName { get; set; }
            public string PanNo { get; set; }
            public int AadharNumber { get; set; }
            public string PrestAddr_HNo { get; set; }
            public string PrestAddr_Street { get; set; }

            public string PrestAddr_City { get; set; }
            public string PrestAddr_State { get; set; }
            public string PrestAddr_Country { get; set; }
            public string PermAddr_HNo { get; set; }
            public string PermAddr_Street { get; set; }

            public string PermAddr_City { get; set; }
            public string PermAddr_State { get; set; }
            public string PermAddr_Country { get; set; }
        

    }
}
