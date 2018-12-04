using Compeer.API.Model;
using Compeer.Core.Entities;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using Compeer.API.Interfaces;

namespace Compeer.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenSetting _tokenSettings;

        public TokenService(TokenSetting tokenSettings)
        {
            _tokenSettings = tokenSettings;    
        }

        public Compeer.API.Model.JsonWebToken GetNewToken(User userToUse)
        {
            var identity = GetClaimsIdentity(userToUse);

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = identity,
                Issuer = _tokenSettings.Issuer,
                Audience = _tokenSettings.Audience,
                IssuedAt = _tokenSettings.IssuedAt,
                NotBefore = _tokenSettings.NotBefore,
                Expires = _tokenSettings.AccessTokenExpiration,
                SigningCredentials = _tokenSettings.SigningCredentials
            });

            var accessToken = handler.WriteToken(securityToken);

            return new Compeer.API.Model.JsonWebToken
            {
                AccessToken = accessToken,
                RefreshToken = CreateRefreshToken(userToUse.Email),
                ExpiresIn = (long) TimeSpan.FromMinutes(_tokenSettings.ValidForMinutes).TotalSeconds
            };
        }

        private RefreshToken CreateRefreshToken(string username)
        {
            var refreshToken = new RefreshToken
            {
                Username = username,
                ExpirationDate = _tokenSettings.RefreshTokenExpiration
            };

            string token;

            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                token = Convert.ToBase64String(randomNumber);
            }

            refreshToken.Token = token.Replace("+", string.Empty)
                .Replace("=", string.Empty)
                .Replace("/", string.Empty);

            return refreshToken;
        }

        private static ClaimsIdentity GetClaimsIdentity(User user)
        {
            var identity = new ClaimsIdentity
            (
                new GenericIdentity(user.Email),
                new[] {
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, user.SummonerName),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("User", user.Email)
                }
            );

            return identity;
        }

        RefreshToken ITokenService.CreateRefreshToken(string username)
        {
            var refreshToken = new RefreshToken
            {
                Username = username,
                ExpirationDate = _tokenSettings.RefreshTokenExpiration
            };

            string token;

            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                token = Convert.ToBase64String(randomNumber);
            }

            refreshToken.Token = token.Replace("+", string.Empty)
                .Replace("=", string.Empty)
                .Replace("/", string.Empty);

            return refreshToken;
        }

        ClaimsIdentity ITokenService.GetClaimsIdentity(User user)
        {
            var identity = new ClaimsIdentity
            (
                new GenericIdentity(user.Email),
                new[] {
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, user.SummonerName),
                    new Claim("UserId", user.Id.ToString())
                }
            );

            return identity;
        }
    }
}