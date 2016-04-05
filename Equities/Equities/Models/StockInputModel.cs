using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equities.Domain;

namespace Equities.Models
{
    public sealed class StockInputModel
    {
        public decimal Price { get; }
        public int Quantity { get; }
        public TypeOfStock StockType { get; }

        public StockInputModel(string price, string quantity, string stockType)
        {
            decimal priceAsDecimal;
            if (!Decimal.TryParse(price, out priceAsDecimal))
                throw new ModelValidationException();
            int quantityAsInteger;
            if (!Int32.TryParse(quantity, out quantityAsInteger))
                throw new ModelValidationException();
            TypeOfStock stockTypeAsEnum;
            if (!Enum.TryParse(stockType, out stockTypeAsEnum))
                throw new ModelValidationException();

            // we obviously want developer-readable exceptions here, but I feel like just the exception framework is enough for this task

            Price = priceAsDecimal;
            Quantity = quantityAsInteger;
            StockType = stockTypeAsEnum;
        }

        public Stock AsStock()
        {
            switch (StockType)
            {
                case TypeOfStock.Bond:
                    return new Bond(Price, Quantity);
                case TypeOfStock.Equity:
                    return new Equity(Price, Quantity);
                default:
                    throw new InvalidOperationException("Unexpected TypeOfStock: " + StockType);
            }
        }
    }
}
