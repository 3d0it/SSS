using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSS.Business;
using SSS.Business.Stocks;
using SSS.Business.Trades;
using SSS.Business.StockIndexes;

namespace SSS.Test
{
    [TestClass]
    public class StockIndexUnitTest
    {
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void InvalidName()
        {
            var stockIndex = new StockIndex("");
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void StockAlreadyAddedTest()
        {
            var stockIndex = new StockIndex("GBCE All Share");
            var s = new Common("POP", 8, 100);
            stockIndex.AddStock(s);
            stockIndex.AddStock(s);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void CalculateStockIndexNoStockAdded()
        {
            var stockIndex = new StockIndex("GBCE All Share");
            decimal stockIndexValue = stockIndex.CalculateIndex();
        }

        [TestMethod]
        public void CalculateStockIndex()
        {
            var stockIndex = new StockIndex("GBCE All Share");

            var s = new Common("POP", 8, 100);
            s.AddTrade(Trade.CreateTrade(DateTime.Now, 2, StockIndicator.Buy, 20));
            stockIndex.AddStock(s);

            var p = new Preferred("GIN", 8, 100, 0.02m);
            p.AddTrade(Trade.CreateTrade(DateTime.Now, 50, StockIndicator.Buy, 10));
            stockIndex.AddStock(p);

            s = new Common("ALE", 23, 60);
            s.AddTrade(Trade.CreateTrade(DateTime.Now, 10, StockIndicator.Sell, 5));
            stockIndex.AddStock(s);

            decimal stockIndexValue = stockIndex.CalculateIndex();
            Assert.IsTrue(stockIndexValue == 10m);
        }
    }
}
