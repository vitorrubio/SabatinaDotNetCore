using CopaSeriesApi.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CopaSeriesTest
{
    [TestClass]
    public class CampeonatoTest
    {
        [TestMethod]
        public void Eliminatorias()
        {
            var competidores = new List<Serie> {
                new Serie {Titulo = "eliminado1", Nota = 10, Ano = 2000},  
                new Serie {Titulo = "Terceiro", Nota = 9, Ano = 2001},
                new Serie {Titulo = "Vice", Nota = 10, Ano = 2002},
                new Serie {Titulo = "Quarto", Nota = 8, Ano = 2003},
                new Serie {Titulo = "eliminado4", Nota = 7, Ano = 2005},
                new Serie {Titulo = "eliminado3", Nota = 6, Ano = 2006},
                new Serie {Titulo = "eliminado2", Nota = 5, Ano = 2007},
                new Serie {Titulo = "Campe�o", Nota = 10, Ano = 2007},
            };

            /* Quartas de Final:
             * Jogo A           - Campe�o   X   eliminado1      => Campe�o
             * Jogo B           - Terceiro  X   eliminado2      => Terceiro
             * Jogo C           - Vice      X   eliminado3      => Vice
             * Jogo D           - Quarto    X   eliminado4      => Quarto
             * 
             * Semifinais:
             * Jogo E           - Campe�o   X   Terceiro        => Campe�o  
             * Jogo F           - Vice      X   Quarto          => Vice
             * 
             * 3� e 4� lugares  - Terceiro  X   Quarto          => Terceiro
             * 
             * Final            - Campe�o   X   Vice            => Campe�o
             * 
             * Resultados: 
             * 1� Lugar - Campe�o
             * 2� Lugar - Vice
             * 3� Lugar - Terceiro
             * 4� Lugar - Quarto 
             */

            var c = new Campeonato(competidores.ToArray());
            Resultado r = c.Eliminatorias();

            Assert.IsNotNull(r);

            Assert.AreEqual("Campe�o", r.Campeao.Titulo);
            Assert.AreEqual("Vice", r.Vice.Titulo);
            Assert.AreEqual("Terceiro", r.TerceiroLugar.Titulo);
            Assert.AreEqual("Quarto", r.QuartoLugar.Titulo);

        }

        [TestMethod]
        public void CriterioDesempateAno()
        {
            var competidores = new List<Serie> {
                new Serie {Titulo = "empate1",   Nota = 10, Ano = 2000},
                new Serie {Titulo = "empate2",   Nota = 10, Ano = 2001},
                new Serie {Titulo = "empate3",   Nota = 10, Ano = 2002},
                new Serie {Titulo = "empate4",   Nota = 10, Ano = 2003},
                new Serie {Titulo = "empate5",   Nota = 10, Ano = 2004},
                new Serie {Titulo = "empate6",   Nota = 10, Ano = 2005},
                new Serie {Titulo = "empate7",   Nota = 10, Ano = 2006},
                new Serie {Titulo = "empate8",   Nota = 10, Ano = 2007},
            };


            var c = new Campeonato(competidores.ToArray());
            Resultado r = c.Eliminatorias();

            Assert.IsNotNull(r);

            Assert.AreEqual("empate8", r.Campeao.Titulo);
            Assert.AreEqual("empate6", r.Vice.Titulo);
            Assert.AreEqual("empate7", r.TerceiroLugar.Titulo);
            Assert.AreEqual("empate5", r.QuartoLugar.Titulo);

        }


        [TestMethod]
        public void CriterioDesempateAlfabetico()
        {
            var competidores = new List<Serie> {
                new Serie {Titulo = "empate1",   Nota = 10, Ano = 2022},
                new Serie {Titulo = "empate2",   Nota = 10, Ano = 2022},
                new Serie {Titulo = "empate3",   Nota = 10, Ano = 2022},
                new Serie {Titulo = "empate4",   Nota = 10, Ano = 2022},
                new Serie {Titulo = "empate5",   Nota = 10, Ano = 2022},
                new Serie {Titulo = "empate6",   Nota = 10, Ano = 2022},
                new Serie {Titulo = "empate7",   Nota = 10, Ano = 2022},
                new Serie {Titulo = "empate8",   Nota = 10, Ano = 2022},
            };


            var c = new Campeonato(competidores.ToArray());
            Resultado r = c.Eliminatorias();

            Assert.IsNotNull(r);

            Assert.AreEqual("empate1", r.Campeao.Titulo);
            Assert.AreEqual("empate3", r.Vice.Titulo);
            Assert.AreEqual("empate2", r.TerceiroLugar.Titulo);
            Assert.AreEqual("empate4", r.QuartoLugar.Titulo);

        }
    }
}
