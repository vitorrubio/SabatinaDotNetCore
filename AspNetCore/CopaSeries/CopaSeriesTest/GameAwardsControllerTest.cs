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
                new Serie {Titulo = "eliminado1", Nota = 10, Ano = 2000},
                new Serie {Titulo = "Terceiro", Nota = 9, Ano = 2001},
                new Serie {Titulo = "Vice", Nota = 10, Ano = 2002},
                new Serie {Titulo = "Quarto", Nota = 8, Ano = 2003},
                new Serie {Titulo = "eliminado4", Nota = 7, Ano = 2005},
                new Serie {Titulo = "eliminado3", Nota = 6, Ano = 2006},
                new Serie {Titulo = "eliminado2", Nota = 5, Ano = 2007},
                new Serie {Titulo = "Campeão", Nota = 10, Ano = 2007},
            };

            var response = controller.Post(competidores.ToArray());

            var actual = response.Result as OkObjectResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual(200, actual.StatusCode);

            var r = actual.Value as Resultado;

            Assert.AreEqual("Campeão", r.Campeao.Titulo);
            Assert.AreEqual("Vice", r.Vice.Titulo);
            Assert.AreEqual("Terceiro", r.TerceiroLugar.Titulo);
            Assert.AreEqual("Quarto", r.QuartoLugar.Titulo);
        }


        [TestMethod]
        public void PostLessThanEight()
        {

            var controller = new SerieAwardsController();

            var competidores = new List<Serie> {
                new Serie {Titulo = "indiferente1", Nota = 9, Ano = 2001},
                new Serie {Titulo = "indiferente2", Nota = 10, Ano = 2002},
                new Serie {Titulo = "indiferente3", Nota = 8, Ano = 2003},
                new Serie {Titulo = "indiferente4", Nota = 7, Ano = 2005},
                new Serie {Titulo = "indiferente5", Nota = 6, Ano = 2006},
                new Serie {Titulo = "indiferente6", Nota = 5, Ano = 2007},
                new Serie {Titulo = "indiferente7", Nota = 10, Ano = 2007},
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
