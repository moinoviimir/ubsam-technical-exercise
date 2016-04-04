using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equities.Domain
{
    public sealed class Bond : Stock
    {
        public Bond(decimal price, int quantity)
            : base(price, quantity)
        {    
        }

        public override TypeOfStock StockType => TypeOfStock.Bond;

        public override decimal TransactionCost => MarketValue * 0.02m;
    }
}
