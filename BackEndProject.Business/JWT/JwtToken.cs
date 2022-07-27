using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.JWT
{
    public class JwtToken
    {
        public string Token { get; set; }
        public DateTime Expration { get; set; }
    }
}
