using SSS.Business.Stocks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.Business.StockIndexes
{
    public class StockIndex
    {
        // Fields
        private string _name;
        private Dictionary<string, Stock> _stocks = new Dictionary<string, Stock>();

        // Properties
        public string Name
        {
            get
            {
                return _name;
            }
        }

        // .Ctors
        public StockIndex(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name can't be empty");

            _name = name;
        }

        // Methods
        public void AddStock(Stock stock)
        {
            if (_stocks.ContainsKey(stock.Symbol.ToUpper()))
                throw new ArgumentException("Stock already added");

            _stocks.Add(stock.Symbol.ToUpper(), stock);
        }
        public decimal CalculateIndex()
        {
            if (!_stocks.Any())
                throw new InvalidOperationException("Stock index not contains stocks");

            decimal product = 1;
            foreach (var stock in _stocks.Values)
            {
                product *= stock.TickerPrice;
            }

            return Convert.ToDecimal(Math.Pow(Convert.ToDouble(product), (1.0 / _stocks.Count)));
        }
    }
}
