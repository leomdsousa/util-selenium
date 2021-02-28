using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Util.Selenium.PageObjects
{
    public class ResultadoPesquisaPageObject
    {
        private IWebElement Home => Driver._driver.FindElement(By.Id("home_img_holder"));
        private IEnumerable<IWebElement>  Filmes => Driver._driver.FindElements(By.XPath("//*[@id='main']/div/div[2]/table/tbody/tr"));
        private IWebElement FindMore => Driver._driver.FindElement(By.ClassName("findMoreMatches"));

        public ResultadoPesquisaPageObject()
        {
            
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
                Console.WriteLine($"----- Início método EscolherFilme({nome}) -----");

                foreach (var item in Filmes.Where(x => x.Text.Contains(nome)))
                {
                    if(!item.TagName.Equals("a"))
                    {
                        item.FindElement(By.XPath("td[2]/a")).Click();
                        return true;
                    }

                    item.Click();

                    Console.WriteLine($"----- Finalização método EscolherFilme({nome}) - Sucesso -----");
                    return true;
                }

                Console.WriteLine($"----- Finalização método EscolherFilme({nome}) - Sem Sucesso -----");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"----- Erro método EscolherFilme({nome}) -----");
                throw ex;
            }
        }
    }
}
