using System;
using System.Collections.Generic;
using System.Linq;
using Equities.Domain.Providers.Interfaces;

namespace Equities.Domain.Providers
{
    public sealed class StockWeightProvider : IStockWeightProvider
    {
        public void UpdateStockWeights(IEnumerable<Stock> stocks)
        {
            if (stocks == null)
                throw new ArgumentNullException(nameof(stocks));

            // we do not convert this to an IList because the collection could be very large
            // and thus interating upon it might just be the only thing left to us
            var totalMarketValue = stocks.Sum(x => x.MarketValue);

            // in case of zero market value everywhere, we have to process it differently
            if (totalMarketValue == 0)
            {
                foreach (var stock in stocks)
                {
                    stock.StockWeight = 0.0m;
                }
            }
            else
            {
                foreach (var stock in stocks)
                {
                    stock.StockWeight = stock.MarketValue/totalMarketValue;
                }
            }
        }
    }
}
