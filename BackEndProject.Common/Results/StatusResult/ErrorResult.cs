using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Common.Results.StatusResult
{
    public class ErrorResult : Result
    {
        public ErrorResult(ResultStatus resultStatus) : base(resultStatus)
        {
        }

        public ErrorResult(ResultStatus resultStatus, bool status, string messages) : base(resultStatus, status, messages)
        {
        }
    }
}
