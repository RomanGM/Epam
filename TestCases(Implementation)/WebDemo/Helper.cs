using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo
{
    class Helper
    {
        public static IWebDriver firefox;

        public static void SetDate( int month = 0, int day = 0 )
        {
            DateTime dt = DateTime.Now;
            ByXPath( "//*[@class=\"rail-departure-date hasDatepicker\"]" ).Click();
            ByXPath( "//*[@data-month=" + ( dt.Month + month - 1 ) + "]/a[text()=" + ( dt.Day + day ) + "]" ).Click();
        }

        public static bool HasError()
        {
            try
            {
                string s = ByXPath( "//*[@class='search-error']/div[1]/b" ).Text;
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public static void ChangeSysDate( int day )
        {
            var proc = new System.Diagnostics.ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"C:\Windows\System32";
            proc.CreateNoWindow = true;
            proc.FileName = @"C:\Windows\System32\cmd.exe";
            proc.Verb = "runas";
            proc.Arguments = "/C date " + ( DateTime.Now.Day + day ) + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
            System.Diagnostics.Process.Start( proc );
        }

        public static void SetInterval( int start, int end )
        {
            ByXPath( "//*[@class='time-range-block']" ).Click();
            ByXPath( "//*[@class='div-select'][1]/select/option[@value=" + start + "]" ).Click();
            ByXPath( "//*[@class='div-select'][2]/select/option[@value=" + end + "]" ).Click();
        }

        public static void SetCountPeople( int count )
        {
            ByXPath( "//*[@class='passengers-adult']/div[@class='passengers-select']/div[text()=" + count + "]" ).Click();
        }

        public static void SetCountChildren( int count )
        {
            ByXPath( "//*[@class='passengers-child']/div[@class='passengers-select']/div[text()=" + count + "]" ).Click();
        }

        public static void Search()
        {
            IWebElement search = ByClass( "search-submit" );
            search.Click();
        }

        public static void Navigate( string url )
        {
            firefox.Navigate().GoToUrl( url );
        }

        public static void SetDestination( string departure, string arrival )
        {
            ById( "departure" ).SendKeys( departure );
            ById( "arrival" ).SendKeys( arrival );
            ById( "arrival" ).SendKeys( Keys.Tab );
        }

        public static void SetDefaultDestination()
        {
            ById( "departure" ).SendKeys( "Минск" );
            ById( "arrival" ).SendKeys( "Москва" );
            ById( "arrival" ).SendKeys( Keys.Tab );
        }

        public static IWebElement ById( string id )
        {
            return firefox.FindElement( By.Id( id ) );
        }

        public static IWebElement ByClass( string className )
        {
            return firefox.FindElement( By.ClassName( className ) );
        }

        public static IWebElement ByXPath( string path )
        {
            return firefox.FindElement( By.XPath( path ) );
        }
    }
}
