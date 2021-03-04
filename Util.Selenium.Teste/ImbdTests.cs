using Moq;
using NUnit.Framework;
using OpenQA.Selenium;
using Util.Selenium.Factories.Interfaces;
using Util.Selenium.PageObjects;
using Util.Selenium.Teste.Mock;

namespace Util.Selenium.Teste
{
    public class Tests
    {
        private readonly ImbdMock _mock;
        private HomePageObject _homePageObject;
        private ResultadoPesquisaPageObject _resultadoPesquisaPageObject;
        private MoviePageObject _moviePageObject;
        private static readonly IImbdFactory _factory;

        public Tests()
        {
            _mock = new ImbdMock();
        }

        [SetUp]
        public void Setup()
        {
            Driver.Instantiate(BrowserType.Chrome);
            _homePageObject = new HomePageObject(Driver._driver);
            _resultadoPesquisaPageObject = new ResultadoPesquisaPageObject(Driver._driver);
            _moviePageObject = new MoviePageObject(Driver._driver);
        }

        [Test]
        public void ImdbFactory_BuscarFilme()
        {
            Assert.Pass();

            //arrange
            _mock.HomePageObject.Setup(x => x.Buscar(It.IsAny<string>())).Returns(Driver._driver);
            _mock.ResultadoPesquisaPageObject.Setup(x => x.EscolherFilme(It.IsAny<string>())).Returns(Driver._driver);
            _mock.MoviePageObject.Setup(x => x.LeituraDadosMovie()).Returns(new Models.Movie());
            _mock.MoviePageObject.Setup(x => x.ExibirDadosMovie(It.IsAny<Models.Movie>())).Returns(true);

            //act
            var result = _factory.BuscarFilme("Titanic");

            //ssert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Models.Movie>(result);
        }

        [Test]
        public void HomePageObject() 
        {
            //arrange
            string nomeFilme = "Titanic";
            Driver._driver.Navigate().GoToUrl(_homePageObject.Url());

            //act
            var result = _homePageObject.Buscar(nomeFilme);

            //ssert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IWebDriver>(result);
        }

        [Test]
        public void ResultadoPesquisaPageObject()
        {
            //arrange
            string nomeFilme = "Titanic";
            Driver._driver.Navigate().GoToUrl("https://www.imdb.com/find?q=" + nomeFilme + "&ref_=nv_sr_sm");

            //act
            var result = _resultadoPesquisaPageObject.EscolherFilme(nomeFilme);

            //ssert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IWebDriver>(result);
        }

        [Test]
        public void MoviePageObject_ExibirDadosMovie()
        {
            //arrange
            Models.Movie movie = new Models.Movie();
            Driver._driver.Navigate().GoToUrl("https://www.imdb.com/title/tt0120338/?ref_=fn_al_tt_1");

            //act
            var result = _moviePageObject.ExibirDadosMovie(movie);

            //ssert
            Assert.IsInstanceOf<bool>(result);
            Assert.True(result);
        }

        [Test]
        public void MoviePageObject_LeituraDadosMovie()
        {
            //arrange
            Models.Movie movie = new Models.Movie();
            Driver._driver.Navigate().GoToUrl("https://www.imdb.com/title/tt0120338/?ref_=fn_al_tt_1");

            //act
            var result = _moviePageObject.LeituraDadosMovie();

            //ssert
            Assert.NotNull(result);
            Assert.IsInstanceOf<Models.Movie>(result);
        }
    }
}