using BackEndProject.Common.Helpers.SecurityKeyHelpers;
using BackEndProject.Common.Helpers.SiginCredantialsHelpers;
using BackEndProject.Entities.ORM.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Business.JWT
{
    public class TokenService : ITokenService
    {
        public IConfiguration Configuration { get; set; }

        private TokenOptions _tokenOptions;
        DateTime _expires;



        public TokenService(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _expires = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpration);
        }

        public JwtToken CreateToken(User userApp, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SiginCredantialsHelper.GetSigningCredentials(securityKey);
            var jwt = CreateSecutiyToken(_tokenOptions, userApp, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new JwtToken()
            {
                Token = token,
                Expration = _expires

            };
        }

        public JwtSecurityToken CreateSecutiyToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {

            var jwt = new JwtSecurityToken(

                  issuer: tokenOptions.Issuer,
                  audience: tokenOptions.Audience,
                 expires: _expires,
                 notBefore: DateTime.Now,
                 claims: SetClaims(user, operationClaims, operationClaims.Select(i => i.Name).ToArray()),
                 signingCredentials: signingCredentials


                );

            return jwt;

        }


        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims, string[] roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, "email"));
            claims.Add(new Claim(ClaimTypes.Name, "name"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, "Id"));

            roles.ToList().ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));

            });


            return claims;





        }
    }
}
