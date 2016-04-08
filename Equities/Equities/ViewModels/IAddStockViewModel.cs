using System.ComponentModel;
using System.Windows.Input;

namespace Equities.ViewModels
{
    public interface IAddStockViewModel
    {
        ICommand AddCommand { get; }
        string Price { get; set; }
        string Quantity { get; set; }
        string StockType { get; set; }
        ICollectionView StockTypes { get; }
    }
}