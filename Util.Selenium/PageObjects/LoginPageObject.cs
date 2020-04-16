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
        }

        //PROPERTIES

        public string url = "https://ead.cursodefrancesonline.com.br/login/index.php";
        IWebElement User => DriverProperties._driver.FindElement(By.Id("username"));
        IWebElement Password => DriverProperties._driver.FindElement(By.Id("password"));
        IWebElement RememberPassword => DriverProperties._driver.FindElement(By.XPath("//*[@id='login']/div[3]/label"));
        IWebElement LoginButton => DriverProperties._driver.FindElement(By.Id("loginbtn"));


        //METHODS

        public void Open()
        {
            DriverProperties._driver.Navigate().GoToUrl(url);
        }
        public void Login(string username, string password, bool rememberPassword)
        {
            User.SendKeys(username);
            Password.SendKeys(password);

            if (rememberPassword && !RememberPassword.Selected)
                RememberPassword.Click();

            LoginButton.Click();
        }
        
        #region MODO DEPRECIADO DE INICIALIZAR A PAGE OBJECT
        //public LoginPageObject()
        //{
        //    PageFactory.InitElements(DriverProperties._driver, this);
        //}

        //[FindsBy(How = How.Id, Using = "username")]
        //public IWebElement User { get; set; }

        //[FindsBy(How = How.Id, Using = "password")]
        //public IWebElement Password { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='login']/div[3]/label")]
        //public IWebElement RememberPassword { get; set; }

        //[FindsBy(How = How.Id, Using = "loginbtn")]
        //public IWebElement LoginButton { get; set; } 
        #endregion
    }
}
