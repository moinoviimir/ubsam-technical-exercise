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
        public ICollectionView Stocks { get; private set; }
        public ReadOnlyObservableCollection<SummaryModel> Summary { get; private set; }

        public ICollectionView StockTypes { get; }

        private Fund _fund;


        public MainWindowViewModel(Fund fund)
        {
            _fund = fund;

            UpdateStocks();

            

            StockTypes = new ListCollectionView(new List<string> {TypeOfStock.Equity.ToString(), TypeOfStock.Bond.ToString()});
        }

        private void UpdateStocks()
        {
            var list = _fund.GetStocks().Select(stock => new StockViewModel(stock)).ToList();
            Stocks = new ListCollectionView(list);

            var summaryList =
                new SummaryBuilder(_fund)
                    .WithEquities()
                    .WithBonds()
                    .WithTotal()
                    .Summary;

            Summary =
                new ReadOnlyObservableCollection<SummaryModel>(
                    new ObservableCollection<SummaryModel>(summaryList));
        }

        public void AddToFund(Stock stock)
        {
            _fund.Add(stock);
            UpdateStocks();
        }

        

        
            
    }
}
