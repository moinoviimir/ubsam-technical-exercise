using System.Collections.Generic;

namespace Equities.Domain.Providers
{
    public interface IStockNameProvider
    {
        IEnumerable<Stock> CreateNames(IEnumerable<Stock> stocks);
        string CreateNewStockName(Stock stock);
    }
}