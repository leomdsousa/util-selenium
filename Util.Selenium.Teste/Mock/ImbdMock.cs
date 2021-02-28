using Moq;
using Util.Selenium.Factories.Interfaces;
using Util.Selenium.Services;
using Util.Selenium.PageObjects;

namespace Util.Selenium.Teste.Mock
{
    class ImbdMock
    {
        #region FACTORY

        public Mock<IImbdFactory> ImdbFactory { get; set; }

        #endregion FACTORY

        #region SERVICE

        public Mock<Navigator> Navigator { get; set; }

        #endregion SERVICE


        #region PAGE OBJECT

        public Mock<HomePageObject> HomePageObject { get; set; }
        public Mock<LoginPageObject> LoginPageObject { get; set; }
        public Mock<MoviePageObject> MoviePageObject { get; set; }
        public Mock<ResultadoPesquisaPageObject> ResultadoPesquisaPageObject { get; set; }

        #endregion PAGE OBJECT

        public ImbdMock()
        {
            ImdbFactory = new Mock<IImbdFactory>();

            Navigator = new Mock<Navigator>();

            HomePageObject = new Mock<HomePageObject>();

            LoginPageObject = new Mock<LoginPageObject>();

            MoviePageObject = new Mock<MoviePageObject>();

            ResultadoPesquisaPageObject = new Mock<ResultadoPesquisaPageObject>();
        }
    }
}
