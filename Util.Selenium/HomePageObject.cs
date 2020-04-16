using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Selenium
{
    public class PageObject
    {
        public PageObject()
        {
            PageFactory.InitElements(DriverProperties._driver, this);
        }

        [FindsBy(How = How.Id, Using = "")]
        public IWebElement MyProperty { get; set; }

    }
}
