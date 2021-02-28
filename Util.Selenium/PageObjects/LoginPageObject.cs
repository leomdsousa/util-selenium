using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Selenium
{
    public class LoginPageObject
    {
        //CONSTRUCTOR
        public LoginPageObject()
        {
        }

        //PROPERTIES
        private const string url = "https://www.imdb.com/";
        private IWebElement User => DriverProperties._driver.FindElement(By.Id("ap_email"));
        private IWebElement Password => DriverProperties._driver.FindElement(By.Id("ap_password"));
        private IWebElement SignInSubmit => DriverProperties._driver.FindElement(By.Id("signInSubmit"));


        //METHODS
        public void Open()
        {
            DriverProperties._driver.Navigate().GoToUrl(url);
        }
        public void Login(string username, string password)
        {
            User.SendKeys(username);
            Password.SendKeys(password);
            SignInSubmit.Click();
        }     
    }
}
