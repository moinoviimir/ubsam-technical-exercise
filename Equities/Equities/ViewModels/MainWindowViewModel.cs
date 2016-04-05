using Equities.Models;

namespace Equities.ViewModels
{
    public sealed class MainWindowViewModel
    {
        public FundViewModel Fund { get; }

        public SummaryViewModel Summary { get; }

        public AddStockViewModel AddStock { get; }

        public MainWindowViewModel()
        {
            Fund = new FundViewModel();
            Summary = new SummaryViewModel(Fund.GetStocksFunc);
            AddStock = new AddStockViewModel(OnStockAdded);
        }

        private void OnStockAdded(StockInputModel stock)
        {
            Fund.AddStock(stock);
            Summary.Update();
        }
    }
}
