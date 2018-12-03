using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Compeer.Core.Interfaces;
using Compeer.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Compeer.API.Services;
using RiotSharp;
using RiotSharp.Interfaces;
using RiotSharp.Misc;
using Compeer.Core.Services;
using System;

namespace Compeer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IService<User> _userService;
        private readonly TokenService _tokenService;

        private readonly IRiotApi _riotApi;

        private readonly UtilService _utilService;

        public RegisterController(
            IService<User> userService,
            TokenService tokenService,
            IRiotApi riotApi,
            UtilService utilService)
        {
            _userService = userService;

            _tokenService = tokenService;

            _riotApi = riotApi;

            _utilService = utilService;
        }
        
        [HttpPost, AllowAnonymous, Route("Create")]
        public async Task<IActionResult> CreateUser([FromBody] User newUser)
        {
            /*
            try
            {
                var summoner = await _riotApi.GetSummonerByNameAsync(Region.br, newUser.SummonerName);

                newUser.Password = _utilService.GenerateHashFromString(newUser.Password);

                newUser.SummonerId = summoner.Id;

                newUser.TimeStamp = DateTime.Now;
            }
            catch (RiotSharpException)
            {                
                return NotFound(new 
                {
                        erro = "404",
                        msg = "SummonerName não encontrado na região Brasil."
                });
            }   
            catch(Exception ex)
            {
                return StatusCode(500, new 
                {
                        erro = "500",
                        msg = $"Erro interno - {ex.Message}"
                });
            }         
            */
            await _userService.AddAsync(newUser);

            if(newUser.Id != 0)
            {
                var tokenToReturn = _tokenService.GetNewToken(newUser);

                return Ok(new 
                {
                    msg = "Usuário criado com sucesso."
                });

            }

            return BadRequest();
        }
    }
}