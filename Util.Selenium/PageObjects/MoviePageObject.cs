using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Util.Selenium.Models;

namespace Util.Selenium.PageObjects
{
    public class MoviePageObject
    {

        public MoviePageObject()
        {

        }

        //PROPERTIES
        private IWebElement Nome => DriverProperties._driver.FindElement(By.ClassName("title_wrapper")).FindElement(By.XPath("h1"));
        private IWebElement Nota => DriverProperties._driver.FindElement(By.ClassName("ratingValue")).FindElement(By.XPath("strong[1]/span[1]"));
        private IWebElement QuantidadeNotas => DriverProperties._driver.FindElement(By.ClassName("imdbRating")).FindElement(By.XPath("a[1]"));        
        
        //private IWebElement DataLancamento => DriverProperties._driver.FindElement(By.ClassName("title_wrapper")).FindElement(By.XPath("h1"));
        private IWebElement Diretor => DriverProperties._driver.FindElement(By.XPath("(//div[@class='credit_summary_item'])[1]/a[1]"));
        private IWebElement Escritor => DriverProperties._driver.FindElement(By.XPath("(//div[@class='credit_summary_item'])[2]/a[1]"));
        private IEnumerable<IWebElement> Atores => DriverProperties._driver.FindElement(By.ClassName("cast_list")).FindElements(By.XPath("(//tr[@class='odd']) | (//tr[@class='even'])"));
        private IEnumerable<IWebElement> Paises => DriverProperties._driver.FindElement(By.Id("titleDetails")).FindElements(By.XPath("div[3]/a"));
        private IEnumerable<IWebElement> Idiomas => DriverProperties._driver.FindElement(By.Id("titleDetails")).FindElements(By.XPath("div[3]/a"));
        private IWebElement Sinopse => DriverProperties._driver.FindElement(By.Id("titleStoryLine")).FindElement(By.XPath("div[1]/p[1]"));
        private IEnumerable<IWebElement> Generos => DriverProperties._driver.FindElement(By.Id("titleDetails")).FindElements(By.XPath("div[4]/a"));
        private IWebElement Orcamento => DriverProperties._driver.FindElement(By.Id("titleDetails")).FindElement(By.XPath("div[7]"));
        private IWebElement ReceitaUSA => DriverProperties._driver.FindElement(By.Id("titleDetails")).FindElement(By.XPath("div[9]"));
        private IWebElement Receita => DriverProperties._driver.FindElement(By.Id("titleDetails")).FindElement(By.XPath("div[10]"));

        //METHODS
        public Movie LeituraDadosMovie()
        {
            try
            {
                Movie movie = new Movie();

                movie.Nome = Nome.Text.Split(Nome.Text.ToCharArray().Where(x => x.ToString().Equals("(")).FirstOrDefault()).First().Trim();
                movie.NotaMedia = Convert.ToDecimal(Nota.Text);
                movie.QuantidadeNotas = Convert.ToDecimal(QuantidadeNotas.Text);
                movie.AnoLancamento = Nome.Text.Split(Nome.Text.ToCharArray().Where(x => x.ToString().Equals("(")).FirstOrDefault()).Last().Replace(")", "").Replace("(", "").Trim();
                movie.Diretor = Diretor.Text;
                movie.Escritor = Escritor.Text;
                //movie.Atores = Atores;
                //movie.Pais = Paises;
                //movie.Atores = Idiomas;
                movie.Sinopse = Sinopse.Text;
                //movie.Generos = Generos;
                movie.Orcamento = Convert.ToDecimal(Regex.Replace(Orcamento.Text, @"(\D)", string.Empty));
                movie.Bilheteria = Convert.ToDecimal(Regex.Replace(Receita.Text, @"(\D)", string.Empty));
                movie.BilheteriaEUA = Convert.ToDecimal(Regex.Replace(ReceitaUSA.Text, @"(\D)", string.Empty));

                return movie;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
