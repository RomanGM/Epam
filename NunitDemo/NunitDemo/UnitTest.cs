using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitDemo
{
    public class UnitTest
    {
        public static double actual;

        [SetUp]
        public static void Pre()
        {
            Console.WriteLine( "Pre Condition" );
        }

        [TearDown]
        public static void Post()
        {
            Console.WriteLine( "Post Condition" );
            actual = 0;
        }

        #region ZeroTests
        [Test]
        public static void ZeroDivTest()
        {
            Assert.That( () => Calculator.Div( double.MaxValue, 0 ), Throws.Exception.TypeOf<DivideByZeroException>() );
        }
        [Test]
        public static void ZeroSumTest()
        {
            actual = Calculator.Sum( double.MaxValue, 0 );
            Assert.AreEqual( double.MaxValue, actual );
        }
        [Test]
        public static void ZeroResTest()
        {
            actual = Calculator.Res( double.MaxValue, 0 );
            Assert.AreEqual( double.MaxValue, actual );
        }
        [Test]
        public static void ZeroMultTest()
        {
            actual = Calculator.Mult( double.MaxValue, 0 );
            Assert.AreEqual( 0, actual );
        }
        #endregion


        #region MinOverflowTests
        [Test]
        public static void MinOverflowSumTest()
        {
            actual = Calculator.Sum( double.MinValue, double.MinValue );
            Assert.True( double.IsNegativeInfinity( actual ) );
        }
        [Test]
        public static void MinOverflowResTest()
        {
            actual = Calculator.Res( double.MinValue, -double.MinValue );
            Assert.True( double.IsNegativeInfinity( actual ) );
        }
        [Test]
        public static void MinOverflowMultTest()
        {
            actual = Calculator.Mult( double.MinValue, -double.MinValue );
            Assert.True( double.IsNegativeInfinity( actual ) );
        }
        [Test]
        public static void MinOverflowDivTest()
        {
            actual = Calculator.Div( double.MinValue, Math.Pow( -double.MinValue, -1 ) );
            Assert.True( double.IsNegativeInfinity( actual ) );
        }
        #endregion


        #region MaxOverflowTests
        [Test]
        public static void MaxOverflowSumTest()
        {
            actual = Calculator.Sum( double.MaxValue, double.MaxValue );
            Assert.True( double.IsPositiveInfinity( actual ) );
        }
        [Test]
        public static void MaxOverflowResTest()
        {
            actual = Calculator.Res( double.MaxValue, -double.MaxValue );
            Assert.True( double.IsPositiveInfinity( actual ) );
        }
        [Test]
        public static void MaxOverflowMultTest()
        {
            actual = Calculator.Mult( double.MaxValue, double.MaxValue );
            Assert.True( double.IsPositiveInfinity( actual ) );
        }
        [Test]
        public static void MaxOverflowDivTest()
        {
            actual = Calculator.Div( double.MaxValue, Math.Pow( double.MaxValue, -1 ) );
            Assert.True( double.IsPositiveInfinity( actual ) );
        }
        #endregion


        #region TwoNegativeTests
        [Test]
        public static void TwoNegativeSumTest()
        {
            actual = Calculator.Sum( -5, -5 );
            Assert.AreEqual( -10, actual );
        }
        [Test]
        public static void TwoNegativeResTest()
        {
            actual = Calculator.Res( -5, -5 );
            Assert.AreEqual( 0, actual );
        }
        [Test]
        public static void TwoNegativeMultTest()
        {
            actual = Calculator.Mult( -5, -5 );
            Assert.AreEqual( 25, actual );
        }
        [Test]
        public static void TwoNegativeDivTest()
        {
            actual = Calculator.Div( -5, -5 );
            Assert.AreEqual( 1, actual );
        }
        #endregion


        #region TwoPositiveTests
        [Test]
        public static void TwoPositiveSumTest()
        {
            actual = Calculator.Sum( 5, 5 );
            Assert.AreEqual( 10, actual );
        }
        [Test]
        public static void TwoPositiveResTest()
        {
            actual = Calculator.Res( 5, 5 );
            Assert.AreEqual( 0, actual );
        }
        [Test]
        public static void TwoPositiveMultTest()
        {
            actual = Calculator.Mult( 5, 5 );
            Assert.AreEqual( 25, actual );
        }
        [Test]
        public static void TwoPositiveDivTest()
        {
            actual = Calculator.Div( 5, 5 );
            Assert.AreEqual( 1, actual );
        }
        #endregion
    }
}
