using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equities.Domain
{
    public abstract class Stock
    {
        public decimal Price { get; }
        public int Quantity { get; }

        protected Stock(decimal price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }
    }
}
