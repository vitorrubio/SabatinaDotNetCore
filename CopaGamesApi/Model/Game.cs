using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaGamesApi.Model
{
    public class Game
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public decimal Nota { get; set; }
        public int Ano { get; set; }
        public string UrlImg { get; set; }
    }
}
