using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equities.Domain
{
    public sealed class Equity : Stock
    {
        public Equity(decimal price, int quantity)
            : base (price, quantity)
        {
        }

        public override TypeOfStock StockType => TypeOfStock.Equity;

        public override decimal TransactionCost => MarketValue * 0.005m;
    }
}
