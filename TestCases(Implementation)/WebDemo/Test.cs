using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;

namespace WebDemo
{
    [TestFixture]
    public class Test
    {
        string rootUrl = "https://biletix.by";

        [SetUp]
        public void Init()
        {
            Helper.firefox = new FirefoxDriver();
        }

        [Test]
        public void EmptyDestination()
        {
            Helper.Navigate( rootUrl );
            Helper.SetDestination( "Минск", "" );
            Assert.AreEqual( Helper.ByClass( "search-submit" ).Enabled, false );
        }

        [Test]
        public void ErrorDestination()
        {
            Helper.Navigate( rootUrl );
            Helper.SetDestination( "Юпитер", "Плутон" );
            Helper.Search();
            Assert.AreEqual( Helper.HasError(), true );
        }

        [Test]
        public void ErrorDate()
        {
            Helper.ChangeSysDate( -1 );
            Helper.Navigate( rootUrl );
            Helper.SetDate();
            Helper.SetDefaultDestination();
            Helper.Search();
            Assert.AreEqual( Helper.HasError(), true );
            Helper.ChangeSysDate( 1 );
        }

        [Test]
        public void ErrorTimeInterval()
        {
            Helper.Navigate( rootUrl );
            Helper.SetDefaultDestination();
            Helper.SetDate();
            Helper.SetInterval( 15, 11 );
            Helper.Search();
            Assert.AreEqual( Helper.HasError(), false );
        }

        [Test]
        public void ErrorTime()
        {
            Helper.Navigate( rootUrl );
            Helper.SetInterval( DateTime.Now.Hour - 2, DateTime.Now.Hour - 1 );
            Helper.SetDefaultDestination();
            Helper.SetDate();
            Helper.Search();
            Assert.AreEqual( Helper.HasError(), true );
        }

        [Test]
        public void LoopbackRoute()
        {
            Helper.Navigate( rootUrl );
            Helper.SetDestination( "Минск", "Минск" );
            Helper.Search();
            Assert.AreEqual( Helper.HasError(), true );
        }

        [Test]
        public void UnCorrectSymbol()
        {
            Helper.Navigate( rootUrl );
            Helper.SetDestination( "?", "Минск" );
            Helper.Search();
            Assert.AreEqual( Helper.HasError(), true );
        }

        [Test]
        public void Overflow()
        {
            Helper.Navigate( rootUrl );
            string bigString = new string( 'z', 50 );
            Helper.SetDestination( bigString, "Минск" );
            Helper.Search();
            Assert.AreEqual( Helper.HasError(), true );
        }

        [Test]
        public void XSSAtack()
        {
            Helper.Navigate( rootUrl );
            Helper.SetDestination( "'fake_data'); alert();", "Минск" );
            Helper.Search();
            Assert.AreEqual( Helper.HasError(), true );
        }

        [Test]
        public void AgeValidation()
        {
            Helper.Navigate( rootUrl );
            Helper.SetDeafultDestination();
            Helper.SetCountPeople( 1 );
            Helper.SetCountChildren( 3 );
            Helper.Search();
            Assert.AreEqual( Helper.HasError(), false );
        }

        //[TearDown]
        //public void Close()
        //{
        //    Helper.firefox.Close();
        //}
    }
}
