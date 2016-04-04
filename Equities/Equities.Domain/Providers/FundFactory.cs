using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equities.Domain.Providers
{
    public sealed class FundFactory
    {
        public Fund Create()
        {
            return new Fund(
                new StockNameProvider(), new StockWeightProvider()
                );
        }
    }
}
