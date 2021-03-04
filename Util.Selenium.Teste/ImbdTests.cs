using NUnit.Framework;
using Util.Selenium.Factories.Interfaces;
using Util.Selenium.Teste.Mock;

namespace Util.Selenium.Teste
{
    public class Tests
    {
        private readonly ImbdMock _mock;
        private static readonly IImbdFactory _factory;

        public Tests()
        {
            _mock = new ImbdMock();
        }

        [SetUp]
        public void Setup()
        {
            Driver.Instantiate(BrowserType.Chrome);
        }

        [Test]
        public void Test1()
        {
            //arrange
            //_mock.Nav.Setup(x => x.).BuscarFilme("Titanic");

            //act
            _factory.BuscarFilme("Titanic");

            //ssert
            Assert.Pass();
        }
    }
}