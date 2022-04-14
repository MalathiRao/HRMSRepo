using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Web.Models
{
    public class Client
    {
        [Display(Name = "Client ID")]
        [Required]
        public int ClientId { get; set; }

        [Display(Name = "Client Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter Client Name")]
        public string ClientName { get; set; }

        [Display(Name = "Address")]
        [StringLength(350)]
        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }

        [Display(Name = "Website")]
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter website url")]
        [Url]
        public string Website { get; set; }

        [Display(Name = "Primary Contact Person Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter Primary Contact Person Name")]
        public string PrimaryContactPersonName { get; set; }

        [Display(Name = "Primary Contact Person Email")]
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter Primary Contact Person Email")]
        [EmailAddress]
        [RegularExpression(@"^([A-Za-z0-9][^'!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ][a-zA-z0-9-._][^!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ]*\@[a-zA-Z0-9][^!&@\\#*$%^?<>()+=':;~`.\[\]{}|/,₹€ ]*\.[a-zA-Z]{2,6})$", ErrorMessage = "Please enter a valid Email")]
        public string PrimaryContactPersonEmail { get; set; }

        [Display(Name = "Secondary Contact Person Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter Secondary Contact Person Name")]
        public string SecondaryContactPersonName { get; set; }

        [Display(Name = "Secondary Contact Person Email")]
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter Secondary Contact Person Email")]
        [EmailAddress]
        [RegularExpression(@"^([A-Za-z0-9][^'!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ][a-zA-z0-9-._][^!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ]*\@[a-zA-Z0-9][^!&@\\#*$%^?<>()+=':;~`.\[\]{}|/,₹€ ]*\.[a-zA-Z]{2,6})$", ErrorMessage = "Please enter a valid Email")]
        public string SecondaryContactPersonEmail { get; set; }
             
    }
}
