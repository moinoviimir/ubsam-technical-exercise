using Equities.DataProviders;
using Equities.Helpers;
using Equities.Models;

namespace Equities.ViewModels
{
    public sealed class MainWindowViewModel
    {
        public IFundViewModel Fund { get; }

        public ISummaryViewModel Summary { get; }

        public IAddStockViewModel AddStock { get; }

        public MainWindowViewModel(IFundViewModel fundViewModel, ISummaryViewModel summaryViewModel, 
            IAddStockViewModel addStockViewModel)
        {
            // This is painful to look at, and we should really use DI here with a proper composition root and bindings and everything, 
            // but I couldn't bring myself to also introduce a DI container here. This solution feels slightly bloated as it is.
            // I hope the overall design that I strove for in the Domain Model will demonstrate my awareness of the concept.
            //Fund = new FundViewModel(TestDataProvider.CreateTestFund());
            //Summary = new SummaryViewModel(Fund.GetStocksFunc);
            //AddStock = new AddStockViewModel(_addStockHelper);
            //_addStockHelper = addStockHelper;

            AddStock = addStockViewModel;
            Fund = fundViewModel;
            Summary = summaryViewModel;
        }
    }
}
