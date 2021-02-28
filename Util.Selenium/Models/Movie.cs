using System;
using System.Collections.Generic;

namespace Util.Selenium.Models
{
    public class Movie
    {
        public Movie()
        {
            Atores = new Dictionary<string, string>();
            Pais = new List<string>();
            Lingua = new List<string>();
            Generos = new List<string>();
        }

        public string Nome { get; set; }
        public DateTime? DataLancamento { get; set; }
        public string AnoLancamento { get; set; }
        public decimal? NotaMedia { get; set; }
        public decimal? QuantidadeNotas { get; set; }
        public string Sinopse { get; set; }
        public string Diretor { get; set; }
        public string Escritor { get; set; }
        public decimal? Orcamento { get; set; }
        public decimal? Bilheteria { get; set; }
        public decimal? BilheteriaEUA { get; set; }
        public string Produtora { get; set; }
        public string Distribuidora { get; set; }
        public Dictionary<string, string> Atores { get; set; }
        public List<string> Pais { get; set; }
        public List<string> Lingua { get; set; }
        public List<string> Generos { get; set; }
    }
}
