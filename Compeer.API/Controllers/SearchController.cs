using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Compeer.Core.Interfaces;
using Compeer.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Compeer.API.Services;
using Compeer.API.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Compeer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IService<User> _userService;
        public SearchController(IService<User> userService)
        {
            _userService = userService;
        }

        [HttpPost, Route("Search")]
        public IActionResult Search([FromBody]TextToSearch textToSearch )
        {
            List<User> users = _userService.Get(u => u.Email.Contains(textToSearch.TextSearch)
            || u.SummonerName.Contains(textToSearch.TextSearch)).ToList();

            if( users.Count == 0 ){
                return Ok(new 
                {
                    msg = "Sem resultados.",
                    term = textToSearch.TextSearch,
                    results = 0
                });
            }else{
                return Ok(new 
                {
                    msg = "Pesquisa realizada.",
                    term = textToSearch.TextSearch,
                    results = users
                });
            }
        }

    }
}