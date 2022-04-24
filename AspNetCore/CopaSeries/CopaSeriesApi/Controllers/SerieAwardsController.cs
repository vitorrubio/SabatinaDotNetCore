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
                new Serie{ Id = "1",  Titulo = "Star Trek", 				Nota =  8.4M, Ano = 1966, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BNDRkMTNiNjgtZDIyOC00NmE1LTlkZjEtMGZiNTcyZDQ0NjcxXkEyXkFqcGdeQXVyNTE1NjY5Mg@@._V1_.jpg" },
                new Serie{ Id = "2",  Titulo = "Star Trek New Generation", 	Nota =  8.7M, Ano = 1987, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BZjRjNzI0MjUtN2M4ZC00YmJlLTg4ZWUtZWVlZDcyMTAzOGUzXkEyXkFqcGdeQXVyMTAyOTE2ODg0._V1_.jpg" },
                new Serie{ Id = "3",  Titulo = "Star Trek Deep Space 9", 	Nota =  8.1M, Ano = 1993, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BMDc3OGNhYjUtZGYwNi00MjllLWE0MjYtNDFiYmVhNWI0MGJmXkEyXkFqcGdeQXVyNTE1NjY5Mg@@._V1_.jpg" },
                new Serie{ Id = "4",  Titulo = "Star Trek Voyager", 		Nota =  7.8M, Ano = 1995, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BYWIwMTI4NzctZmNjZi00OGU2LThhMGItZDI0ODAwOWI1NTFlXkEyXkFqcGdeQXVyNTE1NjY5Mg@@._V1_.jpg" },
                new Serie{ Id = "5",  Titulo = "Star Trek Enterprise", 		Nota =  7.5M, Ano = 2001, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BODg3ZmFmMzAtMTY0Yi00ZDdmLTk1MWMtOThjNjJjODlhMzkwXkEyXkFqcGdeQXVyNTE1NjY5Mg@@._V1_.jpg" },
                new Serie{ Id = "6",  Titulo = "Star Trek Discovery", 		Nota =  7.1M, Ano = 2017, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BNjg1NTc2MDktZTU5Ni00OTZiLWIyNjQtN2FhNGY4MzAxNmZkXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_FMjpg_UX1000_.jpg" },
                new Serie{ Id = "7",  Titulo = "Star Trek Lower Decks", 	Nota =  7.3M, Ano = 2020, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BNjZkNGFmYmYtOGMxNC00ODlhLTkwY2YtNmFiMzU2NzMwZGJlXkEyXkFqcGdeQXVyMDA4NzMyOA@@._V1_.jpg" },
                new Serie{ Id = "8",  Titulo = "Star Trek Picard", 			Nota =  7.4M, Ano = 2020, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BMmMzNTE4MjItYWQwYy00MzMxLWI5NDMtYmQwMGY4MDZlOWU0XkEyXkFqcGdeQXVyMTM1MTE1NDMx._V1_.jpg" },
                new Serie{ Id = "9",  Titulo = "Star Trek Prodgy", 			Nota =  6.9M, Ano = 2021, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BYTA1OGFlN2EtZTI3My00N2U1LThmZGItNjI2N2RmYjRjNTEzXkEyXkFqcGdeQXVyMDA4NzMyOA@@._V1_.jpg" },
                new Serie{ Id = "10", Titulo =  "Breaking Bad", 			Nota =  9.5M, Ano = 2008, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BNGVlZDhiYmItOTYyNi00YjU3LTllYWEtZjgwOTY3NDcwOWJmXkEyXkFqcGdeQXVyMjQwMDg0Ng@@._V1_FMjpg_UX1012_.jpg" },
                new Serie{ Id = "11", Titulo =  "Stranger Things", 			Nota =  8.7M, Ano = 2016, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BYTY2ZjBiNDktOWVkOC00YjgxLTkwNmItYzlmZDM2NmFhMWM2XkEyXkFqcGdeQXVyMTAyOTE2ODg0._V1_FMjpg_UX648_.jpg" },
                new Serie{ Id = "12", Titulo =  "Dark", 					Nota =  8.8M, Ano = 2017, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BMzAwMzQzYTUtNmYxMS00NTE2LWI2NjItMzE4MjBkNzIxYTc5XkEyXkFqcGdeQXVyMTAyOTE2ODg0._V1_FMjpg_UX729_.jpg" },
                new Serie{ Id = "13", Titulo =  "Narcos", 					Nota =  8.8M, Ano = 2015, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BMjIyMjc1MzQ0OF5BMl5BanBnXkFtZTgwNTM4NDcyNjE@._V1_FMjpg_UX663_.jpg" },
                new Serie{ Id = "14", Titulo =  "The Expanse", 				Nota =  8.5M, Ano = 2015, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BZDVmMDljM2QtZDkzZC00ZDg2LWFiMGItZjNiNjliZjg2MGEzXkEyXkFqcGdeQXVyMjkwOTAyMDU@._V1_FMjpg_UX404_.jpg" },
                new Serie{ Id = "15", Titulo =  "Battlestar Galatica", 		Nota =  8.7M, Ano = 2004, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BZjBjMjk4YWQtZjY1MC00NTI5LWEwZDMtYWMyYjk2MjkzMThhXkEyXkFqcGdeQXVyNzA5NjUyNjM@._V1_FMjpg_UX680_.jpg" },
                new Serie{ Id = "16", Titulo =  "Halo", 					Nota =  7.1M, Ano = 2022, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BYzhlOTkzZDMtNDYxYS00NTY2LWJjZDEtNjI3NmE3MTI2NGU2XkEyXkFqcGdeQXVyMTM1MTE1NDMx._V1_.jpg" },
                new Serie{ Id = "17", Titulo =  "Vikings", 					Nota =  8.5M, Ano = 2013, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BODk4ZjU0NDUtYjdlOS00OTljLTgwZTUtYjkyZjk1NzExZGIzXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_FMjpg_UX600_.jpg" },
                new Serie{ Id = "18", Titulo =  "A Roda do Tempo", 			Nota =  7.2M, Ano = 2021, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BYzA2Nzk5M2EtNWY4Yi00ZDY4LThkZTgtYjhhNWEyMGY0MjFjXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_.jpg" },
                new Serie{ Id = "19", Titulo =  "Rick e Morty", 			Nota =  9.2M, Ano = 2013, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BZjRjOTFkOTktZWUzMi00YzMyLThkMmYtMjEwNmQyNzliYTNmXkEyXkFqcGdeQXVyNzQ1ODk3MTQ@._V1_.jpg" },
                new Serie{ Id = "20", Titulo =  "The Walking Dead", 		Nota =  8.2M, Ano = 2010, UrlImagem =  "https://m.media-amazon.com/images/M/MV5BOTc2ZGEzZTItNTNiYS00YTBkLWIzMGEtMjVkMDk1ZjFlZDU2XkEyXkFqcGdeQXVyNjQ0OTk1ODg@._V1_FMjpg_UX716_.jpg" }
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
