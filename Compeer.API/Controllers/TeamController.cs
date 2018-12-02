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
    public class TeamController : ControllerBase
    {
        private readonly IService<User> _userService;
        private readonly TokenService _tokenService;

        public TeamController(
            IService<User> userService
            //TokenService tokenService
            )
        {
            _userService = userService;

            //_tokenService = tokenService;
        }

        [HttpPost, Route("CreateTeam")]
        public ActionResult<string> CreateTeam([FromBody] object dto)
        {
            return BadRequest();
        }

        [HttpPost, Route("JoinTeam")]
        public ActionResult<string> JoinTeam([FromBody] object dto)
        {
            return BadRequest();
        }

        [HttpGet("{id}"), Route("FindTeam")]
        public ActionResult<int> FindTeam(int id)
        {
            return id;
        }

        [HttpPost, Route("AddPlayerTeam")]
        public ActionResult<string> AddPlayerTeam([FromBody] object dto)
        {
            return BadRequest();
        }

        
        [HttpDelete, Route("LeaveTeam")]
        public IActionResult Delete([FromBody] object dto)
        {
            return Ok(dto);
        }
        
    }
}