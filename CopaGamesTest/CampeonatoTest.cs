using CopaGamesApi.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CopaGamesTest
{
    [TestClass]
    public class CampeonatoTest
    {
        [TestMethod]
        public void Eliminatorias()
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

            /*
             * A - OW
             * B - Sonic
             * C - SoT
             * D - Undertale
             * 
             * E - OW | P - Sonic
             * F - SoT | P - Undertale
             * 
             * 3 e 4: Sonic 3, Undertale 4
             * 
             * Cameão OW
             * Vice SoT
             * 
             */

            var c = new Campeonato(competidores.ToArray());
            Resultado r = c.Eliminatorias();

            Assert.IsNotNull(r);

            Assert.AreEqual("Outer Wilds", r.Campeao.Titulo);
            Assert.AreEqual("SoT", r.Vice.Titulo);
            Assert.AreEqual("Sonic", r.TerceiroLugar.Titulo);
            Assert.AreEqual("Undertale", r.QuartoLugar.Titulo);

        }
    }
}
