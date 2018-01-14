using OpenQA.Selenium;
using System;
using WebDemo.Pages;

namespace WebDemo.Steps
{
    public class Steps
    {
        string defaultDeparture = "Минск";
        string defaultArrival = "Москва";

        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void SearchTicket( string departure, string arrival )
        {
            SearchPage searchPage = new SearchPage( driver );
            searchPage.OpenPage();
            searchPage.FillDestination( departure, arrival );
            searchPage.Submit();
        }

        public void SearchWithTime( int min, int max )
        {
            SearchPage searchPage = new SearchPage( driver );
            searchPage.OpenPage();
            searchPage.SetTime( min, max );
            searchPage.FillDestination( defaultDeparture, defaultArrival );
            searchPage.Submit();
        }

        public void SearchWithDate( int month, int day )
        {
            int currentDay = DateTime.Now.Day;
            Helper.ChangeSysDate( day );
            SearchPage searchPage = new SearchPage( driver );
            searchPage.OpenPage();
            searchPage.SetDate( month - 1, day );
            searchPage.FillDestination( defaultDeparture, defaultArrival );
            searchPage.Submit();
            Helper.ChangeSysDate( currentDay );
        }

        public void SearchWithAge( int adultCount, int childrenCount )
        {
            SearchPage searchPage = new SearchPage( driver );
            searchPage.OpenPage();
            searchPage.SetAdultCount( adultCount );
            searchPage.SetChildrenCount( childrenCount );
            searchPage.FillDestination( defaultDeparture, defaultArrival );
            searchPage.Submit();
        }

        public bool IsSubmit()
        {
            return new SearchPage( driver ).IsSubmitEnabled();
        }

        public string ErrorText()
        {
            return new SearchPage( driver ).ErrorBlockText();
        }
    }
}
