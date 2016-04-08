using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Resources;
using Equities.Builders;
using Equities.Domain;
using Equities.Infrastructure;
using Equities.Models;

namespace Equities.ViewModels
{
    public sealed class SummaryViewModel : NotifiableObject, ISummaryViewModel
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

        private readonly ISummaryBuilderFactory _summaryBuilderFactory;

        public SummaryViewModel(ISummaryBuilderFactory summaryBuilderFactory)
        {
            _summaryBuilderFactory = summaryBuilderFactory;
            BuildSummary();
        }

        private void BuildSummary()
        {
            var summaryBuilder = _summaryBuilderFactory.Create();
            var summaryList =
                summaryBuilder
                    .WithEquities()
                    .WithBonds()
                    .WithTotal()
                    .Build();


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
