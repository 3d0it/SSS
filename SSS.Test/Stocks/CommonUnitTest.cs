using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSS.Business.Stocks;
using SSS.Business;
using SSS.Business.Trades;

namespace SSS.Test.Stocks
{
    [TestClass]
    public class CommonUnitTest
    {
        [TestMethod]
        public void CommonPriceDividendYeldTest()
        {
            var s = new Common("POP", 8, 100);
            var t = Trade.CreateTrade(DateTime.Now, 10, StockIndicator.Buy, 20);
            s.AddTrade(t);
            decimal dividendYeld = s.CalculateDividendYeld();
            Assert.IsTrue(dividendYeld == 0.4m);
        }
    }
}
