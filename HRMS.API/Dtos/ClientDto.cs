using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Dtos
{
    public class ClientDto
    {        
        public int ClientId { get; set; }      
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string PrimaryContactPersonName { get; set; }
        public string PrimaryContactPersonEmail { get; set; }
        public string SecondaryContactPersonName { get; set; }
        public string SecondaryContactPersonEmail { get; set; }
    }
}
