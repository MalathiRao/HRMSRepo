using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Dtos
{
    public class LeaveApplicationsDto
    {
        public int LeaveAppId { get; set; }
        public int EmpID { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NoOfDays { get; set; }
        public int LeaveTypeID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByID { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedByID { get; set; }
    }
}
