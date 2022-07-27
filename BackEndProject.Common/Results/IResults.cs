using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Common.Results
{
    public interface IResults
    {
        public ResultStatus ResultStatus { get; set; }
        public bool Status { get; set; }
        public string Messages { get; set; }
    }
}
