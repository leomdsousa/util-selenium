using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Util.Selenium
{
    public class DriverProperties
    {
        public static IWebDriver _driver;

        public static void Instantiate()
        {
            ChromeOptions driverOptions = new ChromeOptions();
            driverOptions.AddArgument("--disable-extensions");
            driverOptions.AddArgument("disable-infobars");
            driverOptions.AddArgument("--silent");
            driverOptions.AddArgument("--incognito");
            //driverOptions.AddArgument("--headless");
            DriverProperties._driver = new ChromeDriver(System.AppDomain.CurrentDomain.BaseDirectory, driverOptions);
        }
    }
}
