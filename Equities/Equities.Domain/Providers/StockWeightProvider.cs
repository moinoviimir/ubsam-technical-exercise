using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equities.Domain.Providers.Interfaces;

namespace Equities.Domain.Providers
{
    public class StockWeightProvider : IStockWeightProvider
    {
        public void UpdateStockWeights(IEnumerable<Stock> stocks)
        {
            if (stocks == null)
                throw new ArgumentNullException(nameof(stocks));

            var list = new List<Stock>(stocks);
            var totalMarketValue = list.Sum(x => x.MarketValue);
            foreach (var stock in list)
            {
                stock.StockWeight = stock.MarketValue / totalMarketValue;
            }
        }
    }
}
