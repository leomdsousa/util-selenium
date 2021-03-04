using System;
using OpenQA.Selenium;

namespace Util.Selenium
{
    public class HomePageObject
    {
        private readonly IWebDriver _driver;

        private static readonly string url = "https://www.imdb.com/";
        private IWebElement BarraPesquisa => _driver.FindElement(By.Id("suggestion-search"));
        private IWebElement BotaoPesquisa => _driver.FindElement(By.Id("suggestion-search-button"));

        public HomePageObject(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebDriver Buscar(string search)
        {
            try
            {
                Console.WriteLine($"----- Início método Buscar({search}) -----");
                Console.WriteLine($"------------------------------------------");

                BarraPesquisa.SendKeys(search);
                BotaoPesquisa.Click();

                Console.WriteLine($"----- Finalização método Buscar({search}) -----");
                Console.WriteLine($"-----------------------------------------------");

                return _driver;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"----- Erro método Buscar({search}) -----");
                Console.WriteLine($"----------------------------------------");
                throw ex;
            }
        }
        public string Url()
        {
            return url;
        }
    }
}
