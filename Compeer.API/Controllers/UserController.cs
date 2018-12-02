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
    public class UserController : ControllerBase
    {
        private readonly IService<User> _userService;
        private readonly TokenService _tokenService;

        public UserController(
            IService<User> userService,
            TokenService tokenService)
        {
            _userService = userService;

            _tokenService = tokenService;
        }

        [HttpPost, Route("ChangePassword")]
        public ActionResult<string> ChangePassword([FromBody] object dto)
        {
            return BadRequest();
        }

        [HttpPost, Route("EditProfile")]
        public ActionResult<string> EditProfile([FromBody] object dto)
        {
            return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult<string> RiotSync(int id)
        {
            return "value";
        }
    }
}