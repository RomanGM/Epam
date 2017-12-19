using NUnit.Framework;
using System;

namespace WebDemo
{
    [TestFixture]
    public class Test
    {
        Steps.Steps steps = new Steps.Steps();
        string defaultArrival = "Москва";
        string defaultDeparture = "Минск";
        string unValidArrival = "Плутон";
        string unCorrectSymbol = "?";
        int hourAgo = DateTime.Now.Hour - 1;
        int twoHoursAgo = DateTime.Now.Hour - 2;
        int yesterday = DateTime.Now.Day - 1;
        string bigString = new string( 'z', 50 );
        string xssString = "'fake_data'); alert();";

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void EmptyDestination()
        {
            steps.SearchTicket( defaultDeparture, String.Empty );
            Assert.AreEqual( steps.IsSubmit(), false );
        }

        [Test]
        public void ErrorDestination()
        {
            steps.SearchTicket( defaultDeparture, unValidArrival );
            Assert.AreEqual( steps.IsError(), true );
        }

        [Test]
        public void ErrorDate()
        {
            steps.SearchWithDate( DateTime.Now.Month, yesterday );
            Assert.AreEqual( steps.IsError(), true );
        }

        [Test]
        public void ErrorTimeInterval()
        {
            steps.SearchWithTime( hourAgo, twoHoursAgo );
            Assert.AreEqual( steps.IsError(), false );
        }

        [Test]
        public void ElapsedTime()
        {
            steps.SearchWithTime( twoHoursAgo, hourAgo );
            Assert.AreEqual( steps.IsError(), true );
        }

        [Test]
        public void LoopbackRoute()
        {
            steps.SearchTicket( defaultDeparture, defaultDeparture );
            Assert.AreEqual( steps.IsError(), true );
        }

        [Test]
        public void UnCorrectSymbol()
        {
            steps.SearchTicket( unCorrectSymbol, defaultArrival );
            Assert.AreEqual( steps.IsError(), true );
        }

        [Test]
        public void Overflow()
        {
            steps.SearchTicket( bigString, defaultArrival );
            Assert.AreEqual( steps.IsError(), true );
        }

        [Test]
        public void XSSAtack()
        {
            steps.SearchTicket( xssString, defaultArrival );
            Assert.AreEqual( steps.IsError(), true );
        }

        [Test]
        public void AgeValidation()
        {
            steps.SearchWithAge( 1, 3 );
            Assert.AreEqual( steps.IsError(), false );
        }
    }
}
