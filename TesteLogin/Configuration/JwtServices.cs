using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TesteLogin.Infrastructure.Data.Entities;

namespace TesteLogin.Configuration
{
    public class JwtServices : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public JwtServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarToken(Login login)
        {
            //var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfiguration:Secret").Value);
            var secret = Encoding.ASCII.GetBytes("MzfsT&d9gprP>!9$Es(X!5g@;ef!5sbk:jH\\2.}8ZP'qY#7");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor

            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, login.Id.ToString()),
                    new Claim(ClaimTypes.Name, login.Usuario.ToString()),
                    new Claim(ClaimTypes.Email, login.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

            return token;
        }
    }
}
