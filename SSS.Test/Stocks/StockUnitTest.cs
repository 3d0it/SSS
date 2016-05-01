using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSS.Business;
using SSS.Business.Stocks;
using SSS.Business.Trades;

namespace SSS.Test.Stocks
{
    [TestClass]
    public class StockUnitTest
    {
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void InvalidLastDividend()
        {
            var s = new Common("POP", -1, 100);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void InvalidParValue()
        {
            var s = new Common("POP", 5, 0);
        }

        [TestMethod]
        public void TestTickerPricePropeerty()
        {
            var s = new Common("POP", 8, 100);
            s.AddTrade(Trade.CreateTrade(DateTime.Now, 2, StockIndicator.Buy, 20));
            s.AddTrade(Trade.CreateTrade(DateTime.Now, 3, StockIndicator.Buy, 21));
            Assert.IsTrue(s.TickerPrice == 21m);
        }

        [TestMethod, ExpectedException(typeof(DivideByZeroException))]
        public void ZeroTickerPriceDividendYeldTest()
        {
            var s = new Common("POP", 8, 100);
            decimal dividendYeld = s.CalculateDividendYeld();
        }

        [TestMethod, ExpectedException(typeof(DivideByZeroException))]
        public void ZeroDividendPeRatioTest()
        {
            var s = new Common("TEA", 0, 100);
            var t = Trade.CreateTrade(DateTime.Now, 10, StockIndicator.Buy, 20);
            s.AddTrade(t);
            decimal dividend = s.CalculatePeRatio();
        }

        [TestMethod]
        public void PeRatioTest()
        {
            var s = new Preferred("GIN", 8, 100, 0.02m);
            var t = Trade.CreateTrade(DateTime.Now, 10, StockIndicator.Buy, 20);
            s.AddTrade(t);
            decimal peRatio = s.CalculatePeRatio();
            Assert.IsTrue(peRatio == 200m);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void CalculateStockPriceTestNoData()
        {
            var s = new Preferred("GIN", 8, 100, 0.02m);
            decimal sp = s.CalculateStockPrice();
        }

        [TestMethod, ExpectedException(typeof(DivideByZeroException))]
        public void CalculateStockPriceTestNoDataLastMinutes()
        {
            var s = new Preferred("GIN", 8, 100, 0.02m);
            var t = Trade.CreateTrade(DateTime.Now.AddMinutes(-20), 10, StockIndicator.Buy, 20);
            s.AddTrade(t);
            decimal sp = s.CalculateStockPrice();
        }

        [TestMethod]
        public void CalculateStockPriceTest()
        {
            var s = new Preferred("GIN", 8, 100, 0.02m);
            var t = Trade.CreateTrade(DateTime.Now.AddMinutes(-5), 10, StockIndicator.Buy, 20);
            s.AddTrade(t);
            t = Trade.CreateTrade(DateTime.Now, 2, StockIndicator.Buy, 26);
            s.AddTrade(t);
            decimal sp = s.CalculateStockPrice();
            Assert.IsTrue(sp == 21);
        }
    }
}
