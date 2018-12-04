using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Compeer.API.Interfaces;

namespace Compeer.API.Model
{
    public class TokenSetting : ITokenSetting
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ValidForMinutes { get; set; }
        public int RefreshTokenValidForMinutes { get; set; }
        public SigningCredentials SigningCredentials { get; }
        public DateTime IssuedAt => DateTime.UtcNow;        
        public DateTime NotBefore => IssuedAt;
        public DateTime AccessTokenExpiration => IssuedAt.AddMinutes(ValidForMinutes);        
        public DateTime RefreshTokenExpiration => IssuedAt.AddMinutes(RefreshTokenValidForMinutes);
    
        public TokenSetting(IConfiguration configuration){
            Issuer = configuration["TokenSettings:Issuer"];

            Audience = configuration["TokenSettings:Audience"];

            ValidForMinutes = Convert.ToInt32(configuration["TokenSettings:ValidForMinutes"]);

            RefreshTokenValidForMinutes = Convert.ToInt32(configuration["TokenSettings:RefreshTokenValidForMinutes"]);

            var signingKey = configuration["TokenSettings:SigningKey"];

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));

            SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}