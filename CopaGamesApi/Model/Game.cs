using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaSeriesApi.Model
{
    public class Serie
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public decimal Nota { get; set; }
        public int Ano { get; set; }
        public string UrlImg { get; set; }
    }
}
