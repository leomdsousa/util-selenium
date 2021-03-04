using Util.Selenium.Services;
using System;
using Util.Selenium.Factories.Interfaces;
using Util.Selenium.Models;
using Util.Selenium.PageObjects;

namespace Util.Selenium.Factories
{
    public class ImbdFactory : IImbdFactory
    {
        public Movie BuscarFilme(string nomeFilme)
        {
            try
            {
                Console.WriteLine($"----- Inicío busca do filme ({nomeFilme}) -----");
                Console.WriteLine($"----------------------------------------  -----");

                if (string.IsNullOrEmpty(nomeFilme))
                {
                    Console.WriteLine($"----- Valor informado irregular -----");
                    Console.WriteLine($"----------------------------------------  -----");
                    return null;
                }

                HomePageObject home = new HomePageObject(Driver._driver);
                NavigatorExtensionMethods.Navigate(home.Url());
                var resultadoPesquisa = home.Buscar(nomeFilme);

                if (resultadoPesquisa == null)
                    return null;

                ResultadoPesquisaPageObject resultado = new ResultadoPesquisaPageObject(Driver._driver);
                var retuladoMovie = resultado.EscolherFilme(nomeFilme);

                if (retuladoMovie == null)
                    return null;

                MoviePageObject movie = new MoviePageObject(Driver._driver);
                Movie dadosFilme = movie.LeituraDadosMovie();
                var exibido = movie.ExibirDadosMovie(dadosFilme);
                
                if (!exibido)
                    return null;

                return dadosFilme;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"----- Erro ao buscar filme ({nomeFilme}) -----");
                Console.WriteLine($"----------------------------------------  -----");
                throw ex;
            }
        }
    }
}
