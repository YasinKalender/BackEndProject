using BackEndProject.Common.Results.DataResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Common.Results.StatusResult
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(bool status) : base(status)
        {
        }
        public ErrorDataResult(T data, ResultStatus resultStatus, bool status, string messages) : base(data, resultStatus, false, messages)
        {
        }
    }
}
