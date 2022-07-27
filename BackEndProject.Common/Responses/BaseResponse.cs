using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Common.Responses
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Exception { get; set; }
        public string ErrorItems { get; set; }
    }
}
