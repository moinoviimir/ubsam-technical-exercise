using System.ComponentModel;
using Equities.Models;

namespace Equities.ViewModels
{
    public interface IFundViewModel
    {
        ICollectionView Stocks { get; }

        void AddStock(StockInputModel model);
    }
}