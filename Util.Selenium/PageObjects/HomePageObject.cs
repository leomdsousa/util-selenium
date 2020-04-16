using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Util.Selenium
{
    public class HomePageObject
    {
        public HomePageObject()
        {
            PageFactory.InitElements(DriverProperties._driver, this);
        }

        [FindsBy(How = How.Id, Using = "")]
        public IWebElement MyProperty { get; set; }

    }
}
