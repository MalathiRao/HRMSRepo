using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API.Dtos
{
    public class HolidayListDto
    {
        public int Serial { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string HolidayType { get; set; }
    }
}
