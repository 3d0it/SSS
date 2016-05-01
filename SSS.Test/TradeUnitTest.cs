using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSS.Business;
using SSS.Business.Trades;

namespace SSS.Test
{
    [TestClass]
    public class TradeUnitTest
    {
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CreateTradeInvalidQuantity()
        {
            Trade.CreateTrade(DateTime.Now, -5, StockIndicator.Buy, 26);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void CreateTradeInvalidPrice()
        {
            Trade.CreateTrade(DateTime.Now, 0, StockIndicator.Buy, 26);
        }

        [TestMethod]
        public void CreateTrade()
        {
            var t = Trade.CreateTrade(DateTime.Now, 10, StockIndicator.Buy, 26);
            Assert.IsNotNull(t);
        }
    }
}
