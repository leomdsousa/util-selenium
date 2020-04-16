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
    class LoginPageObject
    {
        //CONSTRUCTOR
        public LoginPageObject()
        {
            PageFactory.InitElements(DriverProperties._driver, this);
        }

        //PROPERTIES
        public string url = "https://ead.cursodefrancesonline.com.br/login/index.php";        

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement User { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='login']/div[3]/label")]
        public IWebElement RememberUsername { get; set; }

        [FindsBy(How = How.Id, Using = "loginbtn")]
        public IWebElement LoginButton { get; set; }


        //METHODS
        public void Open()
        {
            DriverProperties._driver.Navigate().GoToUrl(url);
        }

        public void Login(string username, string password, bool rememberPassword)
        {
            User.SendKeys(username);
            Password.SendKeys(password);

            if (rememberPassword && !RememberUsername.Selected)
                RememberUsername.Click();

            LoginButton.Click();
        } 
    }
}
