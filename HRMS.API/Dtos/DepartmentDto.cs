using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Dtos
{
    public class DepartmentDto
    {
        public int DeptID { get; set; }
        public int Code { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        
    }
}
