using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Util.Selenium.PageObjects
{
    public class ResultadoPesquisaPageObject
    {

        public ResultadoPesquisaPageObject()
        {
            
        }

        //PROPERTIES
        private IWebElement Home => DriverProperties._driver.FindElement(By.Id("home_img_holder"));
        private IEnumerable<IWebElement>  Filmes => DriverProperties._driver.FindElements(By.XPath("//*[@id='main']/div/div[2]/table/tbody/tr"));
        private IWebElement FindMore => DriverProperties._driver.FindElement(By.ClassName("findMoreMatches"));


        //METHODS
        public void Open(string url)
        {
            DriverProperties._driver.Navigate().GoToUrl(url);
        }

        public bool MenuPrincipal()
        {
            try
            {
                Home.Click();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool ProcurarMais()
        {
            try
            {
                FindMore.Click();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EscolherFilme(string nome)
        {
            try
            {
                foreach (var item in Filmes.Where(x => x.Text.Contains(nome)))
                {
                    if(!item.TagName.Equals("a"))
                    {
                        item.FindElement(By.XPath("td[2]/a")).Click();
                        return true;
                    }

                    item.Click();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
