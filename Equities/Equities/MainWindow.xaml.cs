using System;
using System.Windows;
using Equities.DataProviders;
using Equities.Domain;
using Equities.Domain.Providers;
using Equities.Models;
using Equities.ViewModels;

namespace Equities
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _coreViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _coreViewModel = new MainWindowViewModel();
            DataContext = _coreViewModel;
        }

        private void btnAddStock_Click(object sender, RoutedEventArgs e)
        {
            var stockInputModel = new StockInputModel(txtPrice.Text, txtQuantity.Text, cbType.SelectedValue.ToString());
           _coreViewModel.Fund.AddStock(stockInputModel);
        }
    }
}
