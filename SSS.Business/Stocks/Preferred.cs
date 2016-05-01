using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.Business.Stocks
{
    public class Preferred : Stock
    {
        #region Fields
        private decimal _fixedDividend;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the fixed dividend.
        /// </summary>
        /// <value>
        /// The fixed dividend.
        /// </value>
        public decimal FixedDividend
        {
            get
            {
                return _fixedDividend;
            }
        }
        #endregion

        #region .Ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="Preferred"/> class.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <param name="lastDividend">The last dividend.</param>
        /// <param name="parValue">The par value.</param>
        /// <param name="fixedDividend">The fixed dividend.</param>
        public Preferred(string symbol, int lastDividend, int parValue, decimal fixedDividend)
        {
            Symbol = symbol;
            LastDividend = lastDividend;
            ParValue = parValue;
            _fixedDividend = fixedDividend;
        }
        #endregion

        #region Stock implementation
        /// <summary>
        /// Gets the type of the stock.
        /// </summary>
        /// <value>
        /// The type of the stock.
        /// </value>
        public override StockType StockType
        {
            get
            {
                return StockType.Preferred;
            }
        }
        /// <summary>
        /// Calculates the dividend yeld.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.DivideByZeroException">Ticker price is zero</exception>
        public override decimal CalculateDividendYeld()
        {
            if (TickerPrice == 0)
                throw new DivideByZeroException("Ticker price is zero");

            return (_fixedDividend * ParValue) / TickerPrice;
        }
        #endregion
    }
}
