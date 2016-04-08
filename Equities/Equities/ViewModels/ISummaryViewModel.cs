using System.Collections.ObjectModel;
using Equities.Models;

namespace Equities.ViewModels
{
    public interface ISummaryViewModel
    {
        ReadOnlyObservableCollection<SummaryModel> Contents { get; set; }

        void Update();
    }
}