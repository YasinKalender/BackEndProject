using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Common.Results
{
    public class Result : IResults
    {
        public Result(ResultStatus resultStatus, bool status, string messages) : this(resultStatus, status)
        {
            Messages = messages;

        }

        public Result(ResultStatus resultStatus, bool status)
        {
            Status = status;
            ResultStatus = resultStatus;
        }


        public Result(ResultStatus resultStatus)
        {
            ResultStatus = resultStatus;
        }
        public Result(bool status)
        {
            Status = status;
        }
        public ResultStatus ResultStatus { get; set; }
        public bool Status { get; set; }
        public string Messages { get; set; }
    }
}
