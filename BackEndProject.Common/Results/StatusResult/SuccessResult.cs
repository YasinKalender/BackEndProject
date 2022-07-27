using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Common.Results.StatusResult
{
    public class SuccessResult : Result
    {
        public SuccessResult(ResultStatus resultStatus, bool status, string messages) : base(resultStatus, true, messages)
        {


        }

        public SuccessResult(ResultStatus resultStatus) : base(resultStatus)
        {

        }

    }
}
