using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void oneCanOpenGoogle()
        {
            IWebDriver firefox = new FirefoxDriver();
            firefox.Navigate().GoToUrl("https://github.com/login");

            IWebElement loginField = firefox.FindElement( By.Name( "login" ) );
            loginField.SendKeys( "testautomationuser");

            IWebElement passwordField = firefox.FindElement( By.Name( "password" ) );
            passwordField.SendKeys( "Time4Death!" );

            IWebElement buttonSign = firefox.FindElement( By.Name( "commit" ) );
            buttonSign.Click();
        }
    }
}
