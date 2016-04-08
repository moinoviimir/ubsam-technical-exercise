using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Equities.DataProviders;
using Equities.Domain;
using Equities.Infrastructure;
using Equities.Models;

namespace Equities.ViewModels
{
    /// <summary>
    /// The ViewModel in charge of displaying our Fund business object.
    /// </summary>
    /// <remarks>
    /// This class doesn't take into account that the Fund can contain an extremely large amount of Stocks, thus overflowing our internal Stocks collection.
    /// This is a rather cheap implementation that would have to get reworked should such a situation come into play.
    /// </remarks>
    public sealed class FundViewModel : NotifiableObject, IFundViewModel
    {
        private ICollectionView _stocks;

        public ICollectionView Stocks
        {
            get { return _stocks; }
            private set
            {
                _stocks = value;
                OnPropertyChanged(nameof(Stocks));
            }
        }

        private readonly Fund _fund;

        public FundViewModel(Fund fund)
        {
            var temporaryCollection = fund.GetStocks().Select(stock => new StockViewModel(stock)).ToList();

            Stocks = new ListCollectionView(temporaryCollection);

            _fund = fund;
            GetStocksFunc = fund.GetStocks;
        }

        public void AddStock(StockInputModel model)
        {
            var stock = model.AsStock();
            _fund.Add(stock);
            UpdateStocks();
        }

        private void UpdateStocks()
        {
            var list = _fund.GetStocks().Select(stock => new StockViewModel(stock)).ToList();
            Stocks = new ListCollectionView(list);
        }

        /// <summary>
        /// We expose a means to retrieve the current Stocks of our Fund without the means to modify the collection itself.
        /// We probably want to make it into a ReadOnlyCollection, and I'll do it if I manage to find the time to.
        /// </summary>
        public Func<IEnumerable<Stock>> GetStocksFunc;
    }
}
