using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equities.Domain
{
    public abstract class Stock
    {
        public decimal Price { get; }
        public int Quantity { get; }

        public abstract TypeOfStock StockType { get; }

        public string Name { get; set; }

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
