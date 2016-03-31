using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equities.Domain
{
    public class Equity : Stock
    {
        public Equity(decimal price, int quantity)
            : base (price, quantity)
        {
        }
    }
}
