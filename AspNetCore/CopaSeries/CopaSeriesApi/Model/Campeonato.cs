using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaSeriesApi.Model
{
    public class Campeonato
    {

        private Serie[] _competidores;

        public Campeonato(Serie[] competidores)
        {
            _competidores = competidores;
        }

        public Resultado Eliminatorias()
        {

            if (_competidores == null || _competidores.Count() != 8)
            {
                throw new ArgumentException ("Envie exatamente 8 Series", nameof(_competidores));
            }

            List<Serie> quartasDeFinal = new List<Serie>
            {
                Match(_competidores[0], _competidores[7]),
                Match(_competidores[1], _competidores[6]),
                Match(_competidores[2], _competidores[5]),
                Match(_competidores[3], _competidores[4]),
            };

            List<Serie> semiFinais = new List<Serie>
            {
                Match(quartasDeFinal[0], quartasDeFinal[1], out Serie perdedorJogoE),
                Match(quartasDeFinal[2], quartasDeFinal[3], out Serie perdedorJogoF),
            };

            Serie terceiroLugar = Match(perdedorJogoE, perdedorJogoF, out Serie quartoLugar);

            Serie campeao = Match(semiFinais[0], semiFinais[1], out Serie segundoLugar);

            return new Resultado
            {
                Campeao = campeao,
                Vice = segundoLugar,
                TerceiroLugar = terceiroLugar,
                QuartoLugar = quartoLugar,
            };
        }

        private Serie Match(Serie a, Serie b, out Serie perdedor)
        {
            if (a.Nota > b.Nota)
            {
                perdedor = b;
                return a;
            }
            else if (a.Nota < b.Nota)
            {
                perdedor = a;
                return b;
            }
            else
            {
                return Desempate(a, b, out perdedor);
            }
        }

        private Serie Match(Serie a, Serie b)
        {
            return Match(a, b, out Serie _);
        }

        /// <summary>
        /// desempate por ordem alfabética
        /// </summary>
        private Serie Desempate(Serie a, Serie b, out Serie perdedor)
        {
            if (a.Ano > b.Ano)
            {
                perdedor = b;
                return a;
            }
            else if (a.Ano < b.Ano)
            {
                perdedor = a;
                return b;
            }

            var empatados = new List<Serie> { a, b };
            var vencedor = empatados.OrderBy(g => g.Titulo).First();
            perdedor = empatados.OrderBy(g => g.Titulo).Last();

            return vencedor;
        }
    }
}
