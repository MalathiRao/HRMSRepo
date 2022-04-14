using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Dtos
{
    public class LeaveBalanceDto
    {

        public int LeaveBalanceID { get; set; }     
        public int EmpID { get; set; }     
        public int LeaveTypeID { get; set; }  
        public float NoOfLeavesAllocated { get; set; }
        public float NoOfLeavesRemaining { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByID { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedByID { get; set; }
    }
}
