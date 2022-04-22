using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaGamesApi.Model
{
    public class Resultado
    {
        public Game Campeao { get; set; }
        public Game Vice { get; set; }

        public Game TerceiroLugar { get; set; }

        public Game QuartoLugar { get; set; }
    }
}
