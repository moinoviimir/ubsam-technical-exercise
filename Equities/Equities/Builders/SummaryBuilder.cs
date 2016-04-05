using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equities.Domain;
using Equities.Models;

namespace Equities.Builders
{
    /// <summary>
    /// Builds a Summary based on provided Stocks.
    /// </summary>
    /// <remarks>
    /// This class doesn't take into account that there might be too many Stocks to fit in a single array.
    /// It is a primitive implementation for the front-end designed with readability and ease-of-maintenance in mind.
    /// </remarks>
    public sealed class SummaryBuilder
    {
        private readonly IList<Stock> _stocks;
        private readonly IList<SummaryModel> _result;

        public IEnumerable<SummaryModel> Summary => _result;

        public SummaryBuilder(Func<IEnumerable<Stock>> getStocksAction)
        {
            _stocks = getStocksAction().ToList();
            _result = new List<SummaryModel>();
        }

        public IEnumerable<SummaryModel> Build()
        {
            return _result;
        }

        public SummaryBuilder WithEquities()
        {
            var equities = _stocks.Where(x => x.StockType == TypeOfStock.Equity).ToList();
            var equitySummary = new SummaryModel
            {
                Name = "Equities",
                TotalNumber = equities.Count,
                TotalMarketValue = equities.Sum(x => x.MarketValue),
                TotalStockWeight = equities.Sum(x => x.StockWeight)
            };

            _result.Add(equitySummary);
            return this;
        }

        public SummaryBuilder WithBonds()
        {
            var bonds = _stocks.Where(x => x.StockType == TypeOfStock.Bond).ToList();
            var bondSummary = new SummaryModel
            {
                Name = "Bonds",
                TotalNumber = bonds.Count,
                TotalMarketValue = bonds.Sum(x => x.MarketValue),
                TotalStockWeight = bonds.Sum(x => x.StockWeight)
            };

            _result.Add(bondSummary);
            return this;
        }

        public SummaryBuilder WithTotal()
        {
            var everything = _stocks;
            var totalSummary = new SummaryModel
            {
                Name = "Total",
                TotalNumber = everything.Count,
                TotalMarketValue = everything.Sum(x => x.MarketValue),
                TotalStockWeight = everything.Sum(x => x.StockWeight)
            };

            _result.Add(totalSummary);
            return this;
        }
    }
}
