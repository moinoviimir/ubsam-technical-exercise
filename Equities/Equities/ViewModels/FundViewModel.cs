using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Equities.Domain;

namespace Equities.ViewModels
{
    public class FundViewModel
    {
        public ICollectionView Stocks { get; private set; }


        public FundViewModel(Fund fund)
        {
            var list = fund.GetStocks().Select(stock => new StockViewModel(stock)).ToList();
            Stocks = new ListCollectionView(list);
        }
    }
}
