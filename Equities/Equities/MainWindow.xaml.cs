using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

            DataContext = new FundViewModel(fund);
        }


        //public ObservableCollection<> 
    }
}
