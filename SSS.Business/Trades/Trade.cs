using SSS.Business.Trades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS.Business.Trades
{
    public class Trade
    {
        #region Fields
        private DateTime _timestamp;
        private int _quantity;
        private StockIndicator _indicator;
        private decimal _price;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTime Timestamp
        {
            get
            {
                return _timestamp;
            }
        }
        /// <summary>
        /// Gets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity
        {
            get
            {
                return _quantity;
            }
        }
        /// <summary>
        /// Gets the indicator.
        /// </summary>
        /// <value>
        /// The indicator.
        /// </value>
        public StockIndicator Indicator
        {
            get
            {
                return _indicator;
            }
        }
        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price
        {
            get
            {
                return _price;
            }
        }
        #endregion

        #region .Ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="Trade"/> class.
        /// </summary>
        /// <param name="timestamp">Trade timestamp.</param>
        /// <param name="quantity">Trade quantity.</param>
        /// <param name="indicator">Trade indicator.</param>
        /// <param name="price">Trade price.</param>
        private Trade(DateTime timestamp, int quantity, StockIndicator indicator, decimal price)
        {
            _timestamp = timestamp;
            _quantity = quantity;
            _indicator = indicator;
            _price = price;
        }
        #endregion

        #region Factory Methods
        /// <summary>
        /// Creates a new instance of the <see cref="Trade"/>
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="indicator">The indicator.</param>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        /// Quantity must be greather than zero
        /// or
        /// Price must be greather than zero
        /// </exception>
        public static Trade CreateTrade(DateTime timestamp, int quantity, StockIndicator indicator, decimal price)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greather than zero");

            if (price <= 0)
                throw new ArgumentException("Price must be greather than zero");

            return new Trade(timestamp, quantity, indicator, price);
        }
        #endregion
    }
}
