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

                HomePageObject home = new HomePageObject();
                NavigatorExtensionMethods.Navigate(home.Url());
                var buscado = home.Buscar(nomeFilme);

                if (!buscado)
                    return null;

                ResultadoPesquisaPageObject resultado = new ResultadoPesquisaPageObject();
                resultado.EscolherFilme(nomeFilme);

                MoviePageObject movie = new MoviePageObject();
                Movie dadosFilme = movie.LeituraDadosMovie();
                var exibido = movie.ExibirDadosMovie(dadosFilme);
                
                if (!exibido)
                    return null;

                return dadosFilme;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"----- Erro ao buscar filme ({nomeFilme}) -----");
                throw ex;
            }
        }
    }
}
