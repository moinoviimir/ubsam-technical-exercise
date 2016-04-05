using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Equities.Builders;
using Equities.Domain;
using Equities.Infrastructure;
using Equities.Models;

namespace Equities.ViewModels
{
    public sealed class SummaryViewModel : NotifiableObject
    {
        private ReadOnlyObservableCollection<SummaryModel> _contents;
        public ReadOnlyObservableCollection<SummaryModel> Contents
        {
            get {return _contents;}
            set
            {
                _contents = value;
                OnPropertyChanged(nameof(Contents));
            }
        }

        private Func<IEnumerable<Stock>> _getStocksFunc;

        public SummaryViewModel(Func<IEnumerable<Stock>> getStocksFunc)
        {
            _getStocksFunc = getStocksFunc;
            BuildSummary();
        }

        private void BuildSummary()
        {
            var summaryList =
                new SummaryBuilder(_getStocksFunc)
                    .WithEquities()
                    .WithBonds()
                    .WithTotal()
                    .Summary;


            Contents =
                new ReadOnlyObservableCollection<SummaryModel>(
                    new ObservableCollection<SummaryModel>(summaryList));
        }

        public void Update()
        {
            BuildSummary();
        }
    }
}
