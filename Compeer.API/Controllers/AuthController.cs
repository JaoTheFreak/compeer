using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Compeer.Core.Interfaces;
using Compeer.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Compeer.API.Services;
using Compeer.Core.Services;
using System;
using System.Linq;
using Compeer.API.Interfaces;
using Compeer.API.ViewModel;
using Microsoft.AspNetCore.Cors;

namespace Compeer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IService<User> _userService;
        private readonly ITokenService _tokenService;
        private readonly UtilService _utilService;
        
        public AuthController(
            IService<User> userService,
            ITokenService tokenService,
            UtilService utilService
        )
        {
            _userService = userService;
            _tokenService = tokenService;
            _utilService = utilService;
        }

        [HttpPost, AllowAnonymous, Route("Login")]
        public async Task<IActionResult> Login([FromBody]UserLoginViewModel loginDetails)
        {
            Console.WriteLine($"Attemp to Login : {loginDetails.Email} | {loginDetails.Password}");

            var user = _userService.Get(p => p.Email == loginDetails.Email 
                                        && p.Password == loginDetails.Password).FirstOrDefault();

            if( user == null ) return NotFound( new { message = "O usuário ou senha estão incorretos" } );

            var token = _tokenService.GetNewToken(user);

            Console.WriteLine("Returning Access Token : " + token.AccessToken);

            return Ok(token);

        }

    }
}