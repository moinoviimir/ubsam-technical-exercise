using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Equities.Builders;
using Equities.Domain;
using Equities.Models;

namespace Equities.ViewModels
{
    public sealed class SummaryViewModel
    {
        public ReadOnlyObservableCollection<SummaryModel> Contents { get; }

        public SummaryViewModel(Func<IEnumerable<Stock>> getStocksAction)
        {
            var summaryList =
                new SummaryBuilder(getStocksAction)
                    .WithEquities()
                    .WithBonds()
                    .WithTotal()
                    .Summary;
                

            Contents = 
                new ReadOnlyObservableCollection<SummaryModel>(
                    new ObservableCollection<SummaryModel>(summaryList));
        }
    }
}
