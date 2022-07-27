using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Common.Responses
{
    public class ListResponse<T> : Response<T>
    {
        public int TotalCount { get; set; }
    }
}
