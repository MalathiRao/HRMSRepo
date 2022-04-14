using System.ComponentModel.DataAnnotations;

namespace HRMS.API.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        [StringLength(100)]
        public string ClientName { get; set; }
        [Required]
        [StringLength(450)]
        public string Address { get; set; }
        [Required]
        [StringLength(300)]
        public string Website { get; set; }
        [Required]
        [StringLength(100)]
        public string PrimaryContactPersonName { get; set; }
        [Required]
        [StringLength(100)]
        public string PrimaryContactPersonEmail { get; set; }
        [StringLength(100)]
        public string SecondaryContactPersonName { get; set; }
        [StringLength(100)]
        public string SecondaryContactPersonEmail { get; set; }

    }
}