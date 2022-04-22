using CopaGamesApi.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaGamesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class GameAwardsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            var competidores = new List<Game> {
                new Game {Titulo = "Mario", Nota = 10, Ano = 2000},
                new Game {Titulo = "Sonic", Nota = 9, Ano = 2001},
                new Game {Titulo = "SoT", Nota = 10, Ano = 2002},
                new Game {Titulo = "Undertale", Nota = 8, Ano = 2003},
                new Game {Titulo = "Celeste", Nota = 7, Ano = 2005},
                new Game {Titulo = "Journey", Nota = 6, Ano = 2006},
                new Game {Titulo = "Destiny", Nota = 5, Ano = 2007},
                new Game {Titulo = "Outer Wilds", Nota = 10, Ano = 2007},
            };

            return competidores;
        }



        [HttpPost]
        public ActionResult<Resultado> Post(Game[] competidores)
        {
            if (competidores == null || competidores.Count() != 8)
            {
                return BadRequest("Envie exatamente 8 games");
            }
            Campeonato c = new Campeonato(competidores);

            return Ok(c.Eliminatorias());
        }
    }
}
