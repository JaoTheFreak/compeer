using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Compeer.Core.Interfaces;
using Compeer.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Compeer.API.Services;

namespace Compeer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IService<User> _userService;
        private readonly TokenService _tokenService;

        public RegisterController(
            IService<User> userService,
            TokenService tokenService)
        {
            _userService = userService;

            _tokenService = tokenService;
        }

        [HttpPost, AllowAnonymous, Route("Create")]
        public async Task<IActionResult> CreateUser([FromBody] User newUser)
        {
            await _userService.AddAsync(newUser);

            if(newUser.Id != 0)
            {
                var tokenToReturn = _tokenService.GetNewToken(newUser);

                return Ok(tokenToReturn);
            }

            return BadRequest();
        }
    }
}