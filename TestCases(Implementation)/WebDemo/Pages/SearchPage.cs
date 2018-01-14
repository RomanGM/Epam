using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.Pages
{
    class SearchPage
    {
        private const string BASE_URL = "https://biletix.by";

        [FindsBy( How = How.Id, Using = "departure" )]
        private IWebElement inputDeparture;

        [FindsBy( How = How.Id, Using = "arrival" )]
        private IWebElement inputArrival;

        [FindsBy( How = How.XPath, Using = "//*[@class='rail-departure-date hasDatepicker']" )]
        private IWebElement dateBlock;

        [FindsBy( How = How.ClassName, Using = "time-range-block" )]
        private IWebElement timeBlock;

        [FindsBy( How = How.XPath, Using = "//*[@class='passengers-child']/div[@class='passengers-select']" )]
        private IWebElement blockChild;

        [FindsBy( How = How.XPath, Using = "//*[@class='passengers-adult']/div[@class='passengers-select']" )]
        private IWebElement blockAduit;

        [FindsBy( How = How.ClassName, Using = "search-submit" )]
        private IWebElement buttonSubmit;

        string inputTimeMin = "//*[@class='div-select'][1]/select/option[@value='{0}']";
        string inputTimeMax = "//*[@class='div-select'][2]/select/option[@value='{0}']";
        string errorBlock = "//*[@id='rail_app_view']/div/div[1]/div[3]/div[2]";
        string inputDate = "//*[@data-month='{0}']/a[text()='{1}']";
        string inputCount = ".//div[text()='{0}']";

        private IWebDriver driver;

        public SearchPage( IWebDriver driver )
        {
            this.driver = driver;
            PageFactory.InitElements( this.driver, this );
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl( BASE_URL );
            Console.WriteLine( "Search page opened" );
        }

        public void Submit()
        {
            if (buttonSubmit.Enabled)
            {
                Console.WriteLine( "Submit enable" );
                buttonSubmit.Click();
            }
            else
            {
                Console.WriteLine( "Submit not enable" );
            }
        }

        public bool IsSubmitEnabled()
        {
            return buttonSubmit.Enabled;
        }

        public void FillDestination( string departure, string arrival )
        {
            inputDeparture.SendKeys( departure );
            inputArrival.SendKeys( arrival );
            inputDeparture.Click();
        }

        public void SetDate( int month, int day )
        {
            dateBlock.Click();
            IWebElement buttonDate = dateBlock.FindElement( By.XPath( String.Format( inputDate, month, day ) ) );
            buttonDate.Click();
        }

        public void SetTime( int min, int max )
        {
            timeBlock.Click();
            IWebElement buttonTimeMin = timeBlock.FindElement( By.XPath( String.Format( inputTimeMin, min ) ) );
            buttonTimeMin.Click();
            IWebElement buttonTimeMax = timeBlock.FindElement( By.XPath( String.Format( inputTimeMax, max ) ) );
            buttonTimeMax.Click();
        }

        public void SetAdultCount( int count )
        {
            IWebElement buttonAdult = blockAduit.FindElement( By.XPath( String.Format( inputCount, count ) ) );
            buttonAdult.Click();
        }

        public void SetChildrenCount( int count )
        {
            IWebElement buttonChild = blockChild.FindElement( By.XPath( String.Format( inputCount, count ) ) );
            buttonChild.Click();
        }

        public string ErrorBlockText()
        {
            try
            {
                IWebElement errorElement = driver.FindElement( By.XPath( errorBlock ) );
                return errorElement.Text;
            }
            catch (NoSuchElementException e)
            {
                return "";
            }
        }
    }
}
