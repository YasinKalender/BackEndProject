using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Common.Results.DataResults
{
    public class DataResult<T> : Result, IDataResult<T>
    {

        public DataResult(T data, ResultStatus resultStatus, bool status, string messages) : base(resultStatus, status, messages)
        {
            Data = data;

        }

        public DataResult(T data, ResultStatus resultStatus) : base(resultStatus)
        {
            Data = data;
        }

        public DataResult(bool status) : base(status)
        {
            Status = status;
        }




        public T Data { get; }
    }
}
