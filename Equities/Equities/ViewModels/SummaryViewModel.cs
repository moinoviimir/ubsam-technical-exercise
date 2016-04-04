using System.Collections.ObjectModel;
using Equities.Builders;
using Equities.Domain;
using Equities.Models;

namespace Equities.ViewModels
{
    public sealed class SummaryViewModel
    {
        public readonly ReadOnlyObservableCollection<SummaryModel> Summary;

        public SummaryViewModel(Fund fund)
        {
            var summaryList =
                new SummaryBuilder(fund)
                    .WithEquities()
                    .WithBonds()
                    .WithTotal()
                    .Summary;
                

            Summary = 
                new ReadOnlyObservableCollection<SummaryModel>(
                    new ObservableCollection<SummaryModel>(summaryList));
        }
    }
}
