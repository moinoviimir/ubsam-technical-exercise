using System.Collections.Generic;

namespace Equities.Domain.Providers.Interfaces
{
    public interface IStockWeightProvider
    {
        void UpdateStockWeights(IEnumerable<Stock> stocks);
    }
}