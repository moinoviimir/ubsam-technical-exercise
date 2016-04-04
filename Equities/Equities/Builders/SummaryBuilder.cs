using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equities.Domain;
using Equities.Models;

namespace Equities.Builders
{
    public class SummaryBuilder
    {
        private IList<Stock> _stocks;
        private IList<SummaryModel> _result;

        public IEnumerable<SummaryModel> Summary { get { return _result; } }

        public SummaryBuilder(Fund fund)
        {
            _stocks = fund.GetStocks().ToList();
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
                TotalNumber = everything.Count,
                TotalMarketValue = everything.Sum(x => x.MarketValue),
                TotalStockWeight = everything.Sum(x => x.StockWeight)
            };

            _result.Add(totalSummary);
            return this;
        }
    }
}
