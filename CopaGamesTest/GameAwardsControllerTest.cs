using CopaGamesApi.Controllers;
using CopaGamesApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CopaGamesTest
{
    [TestClass]
    public class GameAwardsControllerTest
    {
        [TestMethod]
        public void PostCompleteGame()
        {

            var controller = new GameAwardsController();

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

            var response = controller.Post(competidores.ToArray());

            var actual = response.Result as OkObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual(200, actual.StatusCode);

            var r = actual.Value as Resultado;

            Assert.AreEqual("Outer Wilds", r.Campeao.Titulo);
            Assert.AreEqual("SoT", r.Vice.Titulo);
            Assert.AreEqual("Sonic", r.TerceiroLugar.Titulo);
            Assert.AreEqual("Undertale", r.QuartoLugar.Titulo);
        }


        [TestMethod]
        public void PostLessThanEight()
        {

            var controller = new GameAwardsController();

            var competidores = new List<Game> {
                new Game {Titulo = "Sonic", Nota = 9, Ano = 2001},
                new Game {Titulo = "SoT", Nota = 10, Ano = 2002},
                new Game {Titulo = "Undertale", Nota = 8, Ano = 2003},
                new Game {Titulo = "Celeste", Nota = 7, Ano = 2005},
                new Game {Titulo = "Journey", Nota = 6, Ano = 2006},
                new Game {Titulo = "Destiny", Nota = 5, Ano = 2007},
                new Game {Titulo = "Outer Wilds", Nota = 10, Ano = 2007},
            };

            var response = controller.Post(competidores.ToArray());

            var actual = response.Result as BadRequestObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual(400, actual.StatusCode);
            Assert.AreEqual("Envie exatamente 8 games", actual.Value);



        }



        [TestMethod]
        public void PostNull()
        {

            var controller = new GameAwardsController();


            var response = controller.Post(null);

            var actual = response.Result as BadRequestObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual(400, actual.StatusCode);
            Assert.AreEqual("Envie exatamente 8 games", actual.Value);

        }
    }
}
