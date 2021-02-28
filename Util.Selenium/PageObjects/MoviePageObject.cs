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

                if (Nome != null)
                    movie.Nome = Nome.Text.Split(Nome.Text.ToCharArray().Where(x => x.ToString().Equals("(")).FirstOrDefault()).First().Trim();

                if(Nota != null)
                    movie.NotaMedia = Convert.ToDecimal(Nota.Text);

                if (QuantidadeNotas != null)
                    movie.QuantidadeNotas = Convert.ToDecimal(QuantidadeNotas.Text);
                
                if (Nome != null)
                    movie.AnoLancamento = Nome.Text.Split(Nome.Text.ToCharArray().Where(x => x.ToString().Equals("(")).FirstOrDefault()).Last().Replace(")", "").Replace("(", "").Trim();
                
                if (Diretor != null)
                    movie.Diretor = Diretor.Text;

                if (Escritor != null)
                    movie.Escritor = Escritor.Text;

                if (Atores != null)
                    Atores?.ToList().ForEach(x => movie.Atores.Add(
                                                    x.Text.Split(new string[] { "..." }, StringSplitOptions.None).First(),
                                                    x.Text.Split(new string[] { "..." }, StringSplitOptions.None).Last()));

                if (Paises != null)
                    Paises?.ToList().ForEach(x => movie.Pais.Add(x.Text));
                
                if (Idiomas != null)
                    Idiomas?.ToList().ForEach(x => movie.Lingua.Add(x.Text));
                
                if (Generos != null)
                    Generos?.ToList().ForEach(x => movie.Generos.Add(x.Text));

                if (Sinopse != null)
                    movie.Sinopse = Sinopse.Text;
                
                if (Orcamento != null)
                    movie.Orcamento = Convert.ToDecimal(Regex.Replace(Orcamento.Text, @"(\D)", string.Empty));

                if (Receita != null)
                    movie.Bilheteria = Convert.ToDecimal(Regex.Replace(Receita.Text, @"(\D)", string.Empty));

                if (ReceitaUSA != null)
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

                Console.WriteLine($"----- Nome: {movie.Nome ?? "Não encontrado"} -----");
                Console.WriteLine($"----- Nota: {movie.NotaMedia.Value.ToString() ?? "Não encontrado"} -----");
                Console.WriteLine($"----- Avaliações: {movie.QuantidadeNotas.Value.ToString() ?? "Não encontrado"} -----");
                Console.WriteLine($"----- Ano Lançamento: {movie.AnoLancamento ?? "Não encontrado"} -----");
                Console.WriteLine($"----- Diretor: {movie.Diretor ?? "Não encontrado"} -----");
                Console.WriteLine($"----- Escritor: {movie.Escritor ?? "Não encontrado"} -----");

                foreach(var ator in movie.Atores)
                {
                    if(!string.IsNullOrEmpty(ator.Key))
                        Console.WriteLine($"----- Ator: {ator.Key} - Personagem: {ator.Value} -----");
                }

                string paises = string.Empty;
                foreach (var pais in movie.Pais)
                {
                    if(!string.IsNullOrEmpty(pais))
                        paises += pais;
                }

                if(!string.IsNullOrEmpty(paises))
                    Console.WriteLine($"----- Países: {paises} -----");

                string idiomas = string.Empty;
                foreach (var idioma in movie.Lingua)
                {
                    if (!string.IsNullOrEmpty(idioma))
                        idiomas += idioma;
                }

                if (!string.IsNullOrEmpty(idiomas))
                    Console.WriteLine($"----- Países: {idiomas} -----");

                Console.WriteLine($"----- Sinopse: {movie.Sinopse ?? "Não encontrado"} -----");

                Console.WriteLine($"----- Orçamento: {movie.Orcamento.Value.ToString() ?? "Não encontrado"} -----");
                Console.WriteLine($"----- Bilheteria: {movie.Bilheteria.Value.ToString() ?? "Não encontrado"} -----");
                Console.WriteLine($"----- Bilheteria (USA): {movie.BilheteriaEUA.Value.ToString() ?? "Não encontrado"} -----");

                string generos = string.Empty;
                foreach (var genero in movie.Generos)
                {
                    if (!string.IsNullOrEmpty(genero))
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
