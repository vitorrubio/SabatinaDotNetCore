using CopaSeriesApi.Controllers;
using CopaSeriesApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CopaSeriesTest
{
    [TestClass]
    public class SerieAwardsControllerTest
    {
        [TestMethod]
        public void PostCompleteSerie()
        {

            var controller = new SerieAwardsController();

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

            var controller = new SerieAwardsController();

            var competidores = new List<Serie> {
                new Serie {Titulo = "Sonic", Nota = 9, Ano = 2001},
                new Serie {Titulo = "SoT", Nota = 10, Ano = 2002},
                new Serie {Titulo = "Undertale", Nota = 8, Ano = 2003},
                new Serie {Titulo = "Celeste", Nota = 7, Ano = 2005},
                new Serie {Titulo = "Journey", Nota = 6, Ano = 2006},
                new Serie {Titulo = "Destiny", Nota = 5, Ano = 2007},
                new Serie {Titulo = "Outer Wilds", Nota = 10, Ano = 2007},
            };

            var response = controller.Post(competidores.ToArray());

            var actual = response.Result as BadRequestObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual(400, actual.StatusCode);
            Assert.AreEqual("Envie exatamente 8 Series", actual.Value);



        }



        [TestMethod]
        public void PostNull()
        {

            var controller = new SerieAwardsController();


            var response = controller.Post(null);

            var actual = response.Result as BadRequestObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual(400, actual.StatusCode);
            Assert.AreEqual("Envie exatamente 8 Series", actual.Value);

        }
    }
}
