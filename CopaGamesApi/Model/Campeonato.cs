using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaGamesApi.Model
{
    public class Campeonato
    {

        private Game[] _competidores;

        public Campeonato(Game[] competidores)
        {
            _competidores = competidores;
        }

        public Resultado Eliminatorias()
        {

            if (_competidores == null || _competidores.Count() != 8)
            {
                throw new ArgumentException ("Envie exatamente 8 games", nameof(_competidores));
            }

            List<Game> quartasDeFinal = new List<Game>
            {
                Match(_competidores[0], _competidores[7]),
                Match(_competidores[1], _competidores[6]),
                Match(_competidores[2], _competidores[5]),
                Match(_competidores[3], _competidores[4]),
            };

            List<Game> semiFinais = new List<Game>
            {
                Match(quartasDeFinal[0], quartasDeFinal[1], out Game perdedorJogoE),
                Match(quartasDeFinal[2], quartasDeFinal[3], out Game perdedorJogoF),
            };

            Game terceiroLugar = Match(perdedorJogoE, perdedorJogoF, out Game quartoLugar);

            Game campeao = Match(semiFinais[0], semiFinais[1], out Game segundoLugar);

            return new Resultado
            {
                Campeao = campeao,
                Vice = segundoLugar,
                TerceiroLugar = terceiroLugar,
                QuartoLugar = quartoLugar,
            };
        }

        private Game Match(Game a, Game b, out Game perdedor)
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

        private Game Match(Game a, Game b)
        {
            return Match(a, b, out Game _);
        }

        /// <summary>
        /// desempate por ordem alfabética
        /// </summary>
        private Game Desempate(Game a, Game b, out Game perdedor)
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

            var empatados = new List<Game> { a, b };
            var vencedor = empatados.OrderBy(g => g.Titulo).First();
            perdedor = empatados.OrderBy(g => g.Titulo).Last();

            return vencedor;
        }
    }
}
