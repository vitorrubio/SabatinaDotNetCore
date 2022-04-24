using CopaSeriesApi.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaSeriesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class SerieAwardsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Serie> Get()
        {
            var competidores = new List<Serie> {
                new Serie {Titulo = "Mario", Nota = 10, Ano = 2000},
                new Serie {Titulo = "Sonic", Nota = 9, Ano = 2001},
                new Serie {Titulo = "SoT", Nota = 10, Ano = 2002},
                new Serie {Titulo = "Undertale", Nota = 8, Ano = 2003},
                new Serie {Titulo = "Celeste", Nota = 7, Ano = 2005},
                new Serie {Titulo = "Journey", Nota = 6, Ano = 2006},
                new Serie {Titulo = "Destiny", Nota = 5, Ano = 2007},
                new Serie {Titulo = "Outer Wilds", Nota = 10, Ano = 2007},
            };

            return competidores;
        }



        [HttpPost]
        public ActionResult<Resultado> Post(Serie[] competidores)
        {
            if (competidores == null || competidores.Count() != 8)
            {
                return BadRequest("Envie exatamente 8 Series");
            }
            Campeonato c = new Campeonato(competidores);

            return Ok(c.Eliminatorias());
        }
    }
}
