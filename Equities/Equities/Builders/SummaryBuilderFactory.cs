using System;
using System.Collections.Generic;
using Equities.Domain;

namespace Equities.Builders
{
    public class SummaryBuilderFactory : ISummaryBuilderFactory
    {
        private readonly Func<IEnumerable<Stock>> _getStocksFunc;

        public SummaryBuilderFactory(Func<IEnumerable<Stock>> getStocksFunc)
        {
            _getStocksFunc = getStocksFunc;
        }

        public ISummaryBuilder Create()
        {
            return new SummaryBuilder(_getStocksFunc);
        }
    }
}
