using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.API
{
    public class ResponseResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class Result
    {
        public Status status { get; set; }
        public object data { get; set; }
    }

    public class Status
    {
        public int code { get; set; }
        public string message { get; set; }
    }
}
