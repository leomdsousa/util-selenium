using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Util.Selenium.Models;
using OpenQA.Selenium;

namespace Util.Selenium.PageObjects
{
    public class MoviePageObject
    {
        private IWebElement Nome => Driver._driver.FindElement(By.ClassName("title_wrapper")).FindElement(By.XPath("h1"));
        private IWebElement Nota => Driver._driver.FindElement(By.ClassName("ratingValue")).FindElement(By.XPath("strong[1]/span[1]"));
        private IWebElement QuantidadeNotas => Driver._driver.FindElement(By.ClassName("imdbRating")).FindElement(By.XPath("a[1]"));        
        
        //private IWebElement DataLancamento => Driver._driver.FindElement(By.ClassName("title_wrapper")).FindElement(By.XPath("h1"));
        private IWebElement Diretor => Driver._driver.FindElement(By.XPath("(//div[@class='credit_summary_item'])[1]/a[1]"));
        private IWebElement Escritor => Driver._driver.FindElement(By.XPath("(//div[@class='credit_summary_item'])[2]/a[1]"));
        private IEnumerable<IWebElement> Atores => Driver._driver.FindElement(By.ClassName("cast_list")).FindElements(By.XPath("(//tr[@class='odd']) | (//tr[@class='even'])"));
        private IEnumerable<IWebElement> Paises => Driver._driver.FindElement(By.Id("titleDetails")).FindElements(By.XPath("div[3]/a"));
        private IEnumerable<IWebElement> Idiomas => Driver._driver.FindElement(By.Id("titleDetails")).FindElements(By.XPath("div[3]/a"));
        private IWebElement Sinopse => Driver._driver.FindElement(By.Id("titleStoryLine")).FindElement(By.XPath("div[1]/p[1]"));
        private IEnumerable<IWebElement> Generos => Driver._driver.FindElement(By.Id("titleDetails")).FindElements(By.XPath("div[4]/a"));
        private IWebElement Orcamento => Driver._driver.FindElement(By.Id("titleDetails")).FindElement(By.XPath("div[7]"));
        private IWebElement ReceitaUSA => Driver._driver.FindElement(By.Id("titleDetails")).FindElement(By.XPath("div[9]"));
        private IWebElement Receita => Driver._driver.FindElement(By.Id("titleDetails")).FindElement(By.XPath("div[10]"));

        public MoviePageObject()
        {

        }
        public Movie LeituraDadosMovie()
        {
            try
            {
                Console.WriteLine($"----- Início método LeituraDadosMovie() -----");

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

                Console.WriteLine($"----- Finalização método LeituraDadosMovie() -----");
                return movie;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"----- Erro método LeituraDadosMovie() -----");
                throw ex;
            }
        }
        public bool ExibirDadosMovie(Movie movie)
        {
            try
            {
                Console.WriteLine($"----- Início método ExibirDadosMovie() -----");

                Console.WriteLine($"----- Dados Filme: -----");

                Console.WriteLine($"----- Nome: {movie.Nome} -----");
                Console.WriteLine($"----- Nota: {movie.NotaMedia} -----");
                Console.WriteLine($"----- Avaliações: {movie.QuantidadeNotas} -----");
                Console.WriteLine($"----- Ano Lançamento: {movie.AnoLancamento} -----");
                Console.WriteLine($"----- Diretor: {movie.Diretor} -----");
                Console.WriteLine($"----- Escritor: {movie.Escritor} -----");

                foreach(var ator in movie.Atores)
                {
                    Console.WriteLine($"----- Ator: {ator} - Personagem: {ator} -----");
                }

                string paises = string.Empty;
                foreach (var pais in movie.Pais)
                {
                    paises += pais;
                }

                if(!string.IsNullOrEmpty(paises))
                    Console.WriteLine($"----- Países: {paises} -----");

                string idiomas = string.Empty;
                foreach (var idioma in movie.Lingua)
                {
                    idiomas += idioma;
                }

                if (!string.IsNullOrEmpty(idiomas))
                    Console.WriteLine($"----- Países: {idiomas} -----");

                Console.WriteLine($"----- Sinopse: {movie.Sinopse} -----");

                Console.WriteLine($"----- Orçamento: {movie.Orcamento} -----");
                Console.WriteLine($"----- Bilheteria: {movie.Bilheteria} -----");
                Console.WriteLine($"----- Bilheteria (USA): {movie.BilheteriaEUA} -----");

                string generos = string.Empty;
                foreach (var genero in movie.Generos)
                {
                    generos += genero;
                }

                if (!string.IsNullOrEmpty(generos))
                    Console.WriteLine($"----- Gênetos: {generos} -----");

                Console.WriteLine($"----- Finalização método ExibirDadosMovie() -----");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"----- Erro método ExibirDadosMovie() -----");
                throw ex;
            }
        }
    }
}
