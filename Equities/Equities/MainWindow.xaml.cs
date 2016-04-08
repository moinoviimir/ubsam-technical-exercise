using System.Windows;
using Equities.Builders;
using Equities.DataProviders;
using Equities.Helpers;
using Equities.ViewModels;

namespace Equities
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // Poor man's DI here - I'm heistant to add a proper IoC container to this already somewhat bloated solution.
            // Given how our dependency tree is shallow enough, this will do.
            // Having the composition root in a Window class is somewhat cringe-inducing, but in the end, I don't think it matters all that much.
            var fundViewModel = new FundViewModel(TestDataProvider.CreateTestFund());
            var summaryViewModel = new SummaryViewModel(new SummaryBuilderFactory(fundViewModel.GetStocksFunc));
            var addStockHelper = new AddStockHelper(
                    fundViewModel,
                    summaryViewModel
                    );
            var addStockViewModel = new AddStockViewModel(addStockHelper);

            var coreViewModel = new MainWindowViewModel(
                fundViewModel,
                summaryViewModel,
                addStockViewModel
                );
                
            DataContext = coreViewModel;
        }

    }
}
