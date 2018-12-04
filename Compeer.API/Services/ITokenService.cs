using Compeer.API.Model;
using Compeer.Core.Entities;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;

namespace Compeer.API.Services
{
    public interface ITokenService
    {
        Compeer.API.Model.JsonWebToken GetNewToken(User userToUse);
        RefreshToken CreateRefreshToken(string username);
        ClaimsIdentity GetClaimsIdentity(User user);
    }
}