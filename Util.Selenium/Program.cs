using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Selenium.PageObjects;

namespace Util.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            DriverProperties.Instantiate();
            Program.ProcessoBuscarFilme("...E o Vento Levou");
        }

        public static void ProcessoBuscarFilme(string filme)
        {
            HomePageObject home = new HomePageObject();
            home.Open();
            var buscado = home.Buscar(filme);

            if (!buscado)
                return;

            ResultadoPesquisaPageObject resultado = new ResultadoPesquisaPageObject();
            resultado.EscolherFilme(filme);

            MoviePageObject movie = new MoviePageObject();
            var dados = movie.LeituraDadosMovie();
        }
    }
}
