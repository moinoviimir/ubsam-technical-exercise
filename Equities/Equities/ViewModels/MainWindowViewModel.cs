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
        public FundViewModel Fund { get; private set; }

        //public ReadOnlyObservableCollection<SummaryModel> Summary { get; private set; }
        public SummaryViewModel Summary { get; private set; }

        public ICollectionView StockTypes { get; }


        public MainWindowViewModel()
        {
            Fund = new FundViewModel();
            Summary = new SummaryViewModel(Fund.GetStocksFunc);

            StockTypes = new ListCollectionView(new List<string> {TypeOfStock.Equity.ToString(), TypeOfStock.Bond.ToString()});
        }
    }
}
