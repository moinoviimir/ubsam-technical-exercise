using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Equities.Builders;
using Equities.Domain;
using Equities.Models;

namespace Equities.ViewModels
{
    public class MainWindowViewModel
    {
        public FundViewModel Fund { get; }

        public SummaryViewModel Summary { get; }

        public StockInputModel StockInput { get; set; }


        public MainWindowViewModel()
        {
            Fund = new FundViewModel();
            Summary = new SummaryViewModel(Fund.GetStocksFunc);
            StockInput = new StockInputModel();
        }
    }
}
