using System;
using OpenQA.Selenium;

namespace Util.Selenium
{
    public class HomePageObject
    {
        private static readonly string url = "https://www.imdb.com/";
        private IWebElement BarraPesquisa => Driver._driver.FindElement(By.Id("suggestion-search"));
        private IWebElement BotaoPesquisa => Driver._driver.FindElement(By.Id("suggestion-search-button"));

        public HomePageObject() { }
        public bool Buscar(string search)
        {
            try
            {
                Console.WriteLine($"----- Início método Buscar({search}) -----");

                BarraPesquisa.SendKeys(search);
                BotaoPesquisa.Click();

                Console.WriteLine($"----- Finalização método Buscar({search}) -----");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"----- Erro método Buscar({search}) -----");
                throw ex;
            }
        }
        public string Url()
        {
            return url;
        }
    }
}
