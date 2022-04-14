using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Dtos
{
    public class ProjectsDto
    {
   
        public int ProjectId { get; set; }
       
        public int? ClientId { get; set; }
      
        public string ProjectCode { get; set; }
        
        public string ProjectName { get; set; }
      
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public String ClientName { get; set; }
  
        public DateTime? EndDate { get; set; }
       
        public string Status { get; set; }

    }
}
