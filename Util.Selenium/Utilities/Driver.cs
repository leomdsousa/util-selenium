using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Util.Selenium
{
    public class Driver
    {
        public static IWebDriver _driver;

        public static void Instantiate(BrowserType browserType)
        {
            try
            {
                Console.WriteLine("----- Inicializando Driver -----");
                Console.WriteLine("--------------------------------");

                if (browserType == BrowserType.Chrome)
                {
                    Console.WriteLine("----- Driver: Chrome -----");
                    Console.WriteLine("--------------------------");

                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--disable-extensions");
                    chromeOptions.AddArgument("disable-infobars");
                    chromeOptions.AddArgument("--silent");
                    chromeOptions.AddArgument("--incognito");
                    //chromeOptions.AddArgument("--headless");
                    Driver._driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, chromeOptions);
                }
                else if(browserType == BrowserType.InternetExplorer)
                {
                    Console.WriteLine("----- Driver: Internet Explorer -----");
                    Console.WriteLine("-------------------------------------");

                    InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                    ieOptions.BrowserAttachTimeout = new TimeSpan(0, 5, 0);
                    Driver._driver = new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory, ieOptions);
                }
                else if(browserType == BrowserType.Firefox)
                {
                    Console.WriteLine("----- Driver: Firefox -----");
                    Console.WriteLine("---------------------------");

                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--disable-extensions");
                    firefoxOptions.AddArgument("disable-infobars");
                    firefoxOptions.AddArgument("--silent");
                    firefoxOptions.AddArgument("--incognito");
                    //driverOptions.AddArgument("--headless");
                    Driver._driver = new FirefoxDriver(AppDomain.CurrentDomain.BaseDirectory, firefoxOptions);
                }

                Console.WriteLine("----- Inicialização do Driver concluída -----");
                Console.WriteLine("---------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("----- Erro ao inicializar Driver -----");
                Console.WriteLine("--------------------------------------");
                throw;
            }
        }
    }
}
