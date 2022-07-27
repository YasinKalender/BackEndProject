using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Common.Helpers.SiginCredantialsHelpers
{
    public class SiginCredantialsHelper
    {
        public static SigningCredentials GetSigningCredentials(SecurityKey securityKey)
        {

            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
