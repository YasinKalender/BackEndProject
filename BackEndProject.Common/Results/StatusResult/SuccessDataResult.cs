using BackEndProject.Common.Results.DataResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Common.Results.StatusResult
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, ResultStatus resultStatus, bool status, string messages) : base(data, resultStatus, status, messages)
        {


        }

        public SuccessDataResult(bool status) : base(status)
        {
        }



    }
}
