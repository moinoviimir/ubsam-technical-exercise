using Equities.Models;

namespace Equities.ViewModels
{
    public class MainWindowViewModel
    {
        public FundViewModel Fund { get; }

        public SummaryViewModel Summary { get; }

        //public StockInputModel StockInput { get; set; }
        public AddStockViewModel AddStock { get; set; }


        public MainWindowViewModel()
        {
            Fund = new FundViewModel();
            Summary = new SummaryViewModel(Fund.GetStocksFunc);
            //StockInput = new StockInputModel();
            AddStock = new AddStockViewModel();
        }
    }
}
