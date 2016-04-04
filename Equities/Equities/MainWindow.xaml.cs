using System;
using System.Windows;
using Equities.Domain;
using Equities.Domain.Providers;
using Equities.ViewModels;

namespace Equities
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();

            var fund = new FundFactory().Create();
            var bond = new Bond(10.0m, 5);
            var equity = new Equity(2.5m, 4);
            var bond2 = new Bond(3.5m, 6);
            fund.Add(bond);
            fund.Add(equity);
            fund.Add(bond2);

            _vm = new MainWindowViewModel(fund);
            DataContext = _vm;
        }

        private void btnAddStock_Click(object sender, RoutedEventArgs e)
        {
            var price = Decimal.Parse(txtPrice.Text);
            var quantity = Int32.Parse(txtQuantity.Text);
            Stock stock;
            var selectedType = Enum.Parse(typeof (TypeOfStock), cbType.SelectedValue.ToString());
            if ((TypeOfStock) selectedType == TypeOfStock.Equity)
                stock = new Equity(price, quantity);
            else
                stock = new Bond(price, quantity);

           _vm.AddToFund(stock);
        }
    }
}
