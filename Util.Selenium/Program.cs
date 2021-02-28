using System;
using Util.Selenium.Factories;

namespace Util.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- Início Processo -----");

            Console.WriteLine("----- Infore um filme na qual deseja ver informações: -----");

            var filmeEscolhido = Console.ReadLine();

            Driver.Instantiate(BrowserType.Chrome);
            ImbdFactory _imbdFactory = new ImbdFactory();
            _imbdFactory.BuscarFilme(filmeEscolhido);

            Console.WriteLine("----- Fim Processo -----");
        }
    }
}
