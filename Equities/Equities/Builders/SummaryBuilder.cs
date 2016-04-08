using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;
using Equities.Domain;
using Equities.Models;

namespace Equities.Builders
{
    /// <summary>
    /// Builds a Summary based on provided Stocks.
    /// </summary>
    /// <remarks>
    /// This class doesn't take into account that there might be too many Stocks to fit in a single array.
    /// This is a primitive implementation for the front-end designed with readability and ease-of-maintenance in mind.
    /// </remarks>
    public sealed class SummaryBuilder : ISummaryBuilder
    {
        private readonly IList<Stock> _stocks;
        private readonly IList<SummaryModel> _result;

        public SummaryBuilder(Func<IEnumerable<Stock>> getStocksAction)
        {
            _stocks = getStocksAction().ToList();
            _result = new List<SummaryModel>();
        }

        public IEnumerable<SummaryModel> Build()
        {
            return _result;
        }

        public ISummaryBuilder WithEquities()
        {
            var equities = _stocks.Where(x => x.StockType == TypeOfStock.Equity).ToList();
            if (equities.Count == 0)
                return this;

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

        public ISummaryBuilder WithBonds()
        {
            var bonds = _stocks.Where(x => x.StockType == TypeOfStock.Bond).ToList();
            if (bonds.Count == 0)
                return this;

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

        public ISummaryBuilder WithTotal()
        {
            var everything = _stocks;
            if (everything.Count == 0)
                return this;

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
