using System.Collections.Generic;

namespace Equities.Domain.Providers
{
    public interface IStockNameProvider
    {
        string CreateNewStockName(Stock stock);
    }
}