using SSS.Business.Trades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.Business.Stocks
{
    public abstract class Stock
    {
        #region Fields
        private string _symbol;
        private int _lastDividend;
        private int _parValue;
        private List<Trade> _trades = new List<Trade>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
            protected set
            {
                _symbol = value;
            }
        }
        /// <summary>
        /// Gets or sets the Stock last dividend.
        /// </summary>
        /// <value>
        /// The last dividend.
        /// </value>
        /// <exception cref="System.ArgumentException">LastDividend can't be negative</exception>
        public int LastDividend
        {
            get
            {
                return _lastDividend;
            }
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("LastDividend can't be negative");

                _lastDividend = value;
            }
        }
        /// <summary>
        /// Gets or sets the par value.
        /// </summary>
        /// <value>
        /// The par value.
        /// </value>
        /// <exception cref="System.ArgumentException">ParValue must be greather than zero</exception>
        public int ParValue
        {
            get
            {
                return _parValue;
            }
            protected set
            {
                if (value <= 0)
                    throw new ArgumentException("ParValue must be greather than zero");

                _parValue = value;
            }

        }
        /// <summary>
        /// Gets the ticker price.
        /// </summary>
        /// <value>
        /// The ticker price.
        /// </value>
        public decimal TickerPrice
        {
            get
            {
                if (_trades.Any())
                    return _trades.Last().Price; // Last complexity O(1)
                else
                    return 0;
            }
        }
        /// <summary>
        /// Gets the type of the stock.
        /// </summary>
        /// <value>
        /// The type of the stock.
        /// </value>
        public abstract StockType StockType
        {
            get;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calculates the pe ratio.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.DivideByZeroException">Dividend is zero</exception>
        public decimal CalculatePeRatio()
        {
            decimal dividend = CalculateDividendYeld();
            if (dividend == 0)
                throw new DivideByZeroException("Dividend is zero");

            return TickerPrice / dividend;
        }
        /// <summary>
        /// Adds the trade.
        /// </summary>
        /// <param name="trade">The trade.</param>
        public void AddTrade(Trade trade)
        {
            _trades.Add(trade);
        }
        /// <summary>
        /// Calculates the stock price.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">No trades available for this stock</exception>
        /// <exception cref="System.DivideByZeroException">Sum of quantities is zero</exception>
        public decimal CalculateStockPrice()
        {
            if (!_trades.Any())
                throw new InvalidOperationException("No trades available for this stock");

            decimal quantities = 0;
            decimal priceQuantities = 0;

            var lastTrades = _trades.Where(t => DateTime.Now.Subtract(t.Timestamp).TotalMinutes <= 15);

            foreach (var trade in lastTrades)
            {
                quantities += trade.Quantity;
                priceQuantities += (trade.Price * trade.Quantity);
            }

            if (quantities == 0)
                throw new DivideByZeroException("Sum of quantities is zero");

            return priceQuantities / quantities;
        }
        /// <summary>
        /// Calculates the dividend yeld.
        /// </summary>
        /// <returns></returns>
        public abstract decimal CalculateDividendYeld();
        #endregion
    }
}
