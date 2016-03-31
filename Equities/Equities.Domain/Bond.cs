using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equities.Domain
{
    public class Bond : Stock
    {
        public Bond(decimal price, int quantity)
            : base(price, quantity)
        {
            
        }
    }
}
