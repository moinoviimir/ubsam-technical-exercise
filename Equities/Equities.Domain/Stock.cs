using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equities.Domain
{
    /// <summary>
    /// The parent class for a Stock. Represents a financial instrument with a set of common characteristics.
    /// </summary>
    public abstract class Stock
    {
        /// <summary>
        /// The price of a unit of the instrument.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// The quantity of Stock bought.
        /// </summary>
        public int Quantity { get; }

        /// <summary>
        /// The type of the Stock. Different types have different transaction costs.
        /// </summary>
        public abstract TypeOfStock StockType { get; }

        /// <summary>
        /// The human-readable name of the Stock.
        /// </summary>
        /// <remarks>
        /// An argument could be made for this to be moved over to the ViewModel, 
        /// but not having a kind of name or identifier for an entity just feels wrong.
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// The market value of the Stock.
        /// </summary>
        public decimal MarketValue => Price * Quantity;

        /// <summary>
        /// The price of a transaction using this particular kind of Stock.
        /// </summary>
        public abstract decimal TransactionCost { get; }

        /// <summary>
        /// The weight of the Stock within its Fund.
        /// </summary>
        public decimal StockWeight { get; set; }

        protected Stock(decimal price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }
    }

    public enum TypeOfStock
    {
        Equity,
        Bond
    };
}
