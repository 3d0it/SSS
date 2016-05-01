using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.Business.Stocks
{
    public class Common : Stock
    {
        #region .Ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="Common"/> class.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        /// <param name="lastDividend">The last dividend.</param>
        /// <param name="parValue">The par value.</param>
        public Common (string symbol, int lastDividend, int parValue)
        {
            Symbol = symbol;
            LastDividend = lastDividend;
            ParValue = parValue;
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
                return StockType.Common;
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

            return LastDividend / TickerPrice;
        }
        #endregion
    }
}
