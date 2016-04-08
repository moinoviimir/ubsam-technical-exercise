using Equities.Models;
using Equities.ViewModels;

namespace Equities.Helpers
{
    public sealed class AddStockHelper : IAddStockHelper
    {
        private readonly FundViewModel _fundViewModel;
        private readonly SummaryViewModel _summaryViewModel;

        public AddStockHelper(FundViewModel fundViewModel, SummaryViewModel summaryViewModel)
        {
            _fundViewModel = fundViewModel;
            _summaryViewModel = summaryViewModel;
        }

        public void AddStock(StockInputModel model)
        {
            _fundViewModel.AddStock(model);
            _summaryViewModel.Update();
        }
    }
}
