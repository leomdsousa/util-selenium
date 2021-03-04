using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Util.Selenium.PageObjects
{
    public class ResultadoPesquisaPageObject
    {
        private readonly IWebDriver _driver;
        private IWebElement Home => _driver.FindElement(By.Id("home_img_holder"));
        private IEnumerable<IWebElement>  Filmes => _driver.FindElements(By.XPath("//*[@id='main']/div/div[2]/table/tbody/tr"));
        private IWebElement FindMore => _driver.FindElement(By.ClassName("findMoreMatches"));

        public ResultadoPesquisaPageObject(IWebDriver driver)
        {
            _driver = driver;
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
        public IWebDriver EscolherFilme(string nome)
        {
            try
            {
                Console.WriteLine($"----- Início método EscolherFilme({nome}) -----");
                Console.WriteLine($"-----------------------------------------------");

                foreach (var item in Filmes.Where(x => x.Text.Contains(nome)))
                {
                    if(!item.TagName.Equals("a"))
                    {
                        item.FindElement(By.XPath("td[2]/a")).Click();
                        return _driver;
                    }

                    item.Click();

                    Console.WriteLine($"----- Finalização método EscolherFilme({nome}) - Sucesso -----");
                    Console.WriteLine($"--------------------------------------------------------------");
                    return _driver;
                }

                Console.WriteLine($"----- Finalização método EscolherFilme({nome}) - Sem Sucesso -----");
                Console.WriteLine($"------------------------------------------------------------------");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"----- Erro método EscolherFilme({nome}) -----");
                Console.WriteLine($"---------------------------------------------");
                throw ex;
            }
        }
    }
}
