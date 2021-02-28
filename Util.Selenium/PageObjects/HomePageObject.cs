using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Util.Selenium
{
    public class HomePageObject
    {
        public HomePageObject()
        {

        }

        public HomePageObject(string url)
        {
            Open(url);
        }

        public void Open(string url)
        {
            DriverProperties._driver.Navigate().GoToUrl(url);
        }

        public void Open()
        {
            DriverProperties._driver.Navigate().GoToUrl(url);
        }

        public bool Buscar(string search)
        {
            try
            {
                BarraPesquisa.SendKeys(search);
                BotaoPesquisa.Click();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //PROPERTIES
        private const string url = "https://www.imdb.com/";
        private IWebElement BarraPesquisa => DriverProperties._driver.FindElement(By.Id("suggestion-search"));
        private IWebElement BotaoPesquisa => DriverProperties._driver.FindElement(By.Id("suggestion-search-button"));


    }
}
