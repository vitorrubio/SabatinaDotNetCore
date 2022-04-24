using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaSeriesApi.Model
{
    public class Resultado
    {
        public Serie Campeao { get; set; }
        public Serie Vice { get; set; }

        public Serie TerceiroLugar { get; set; }

        public Serie QuartoLugar { get; set; }
    }
}
