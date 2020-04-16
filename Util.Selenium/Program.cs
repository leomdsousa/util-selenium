using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            DriverProperties.Instantiate();
            Program.Teste();
        }

        [Test]
        public static void Teste()
        {
            LoginPageObject loginPageObject = new LoginPageObject();
            loginPageObject.Open();
            loginPageObject.Login("leonardomdsousa@gmail.com", "IfespCfo123*", false);
        }
    }
}
