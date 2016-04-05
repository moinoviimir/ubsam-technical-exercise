using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using Equities.Domain;
using Equities.Infrastructure;

namespace Equities.ViewModels
{
    public sealed class AddStockViewModel : INotifyPropertyChanged
    {
        private string _price;
        private string _quantity;

        public string Price
        {
            get { return _price;}
            set
            {
                _price = value;
                _addCommand.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(Price));
                ValidateModel();
            }
        }

        public string Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                _addCommand.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(Quantity));
                ValidateModel();
            }
        }

        public string StockType {get; set; }

        public ICollectionView StockTypes { get; }

        private readonly DelegateCommand _addCommand;
        public ICommand AddCommand => _addCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public string ErrorTooltip {
            get { return _errorTooltip; }
            set
            {
                _errorTooltip = value;
                OnPropertyChanged(nameof(ErrorTooltip));
            }
        }
        private string _errorTooltip;


        public AddStockViewModel()
        {
            StockTypes = new ListCollectionView(new List<string> { TypeOfStock.Equity.ToString(), TypeOfStock.Bond.ToString() });
            _addCommand = new DelegateCommand(o => AddNewStock(), o => IsModelValid());
        }

        private bool IsModelValid()
        {
            return IsPriceValid() && IsQuantityValid();
        }

        private bool IsQuantityValid()
        {
            int tempQuantity;
            return Int32.TryParse(_quantity, out tempQuantity);
        }

        private bool IsPriceValid()
        {
            decimal tempDecimal;
            return Decimal.TryParse(_price, out tempDecimal);
        }

        private void ValidateModel()
        {
            if (!IsPriceValid())
                ErrorTooltip = "Price is expected to be a decimal number";
            else if (!IsQuantityValid())
                ErrorTooltip = "Quantity is expected to be an integer";
            else
                ErrorTooltip = "Adds the stock";
        }

        private void AddNewStock()
        {
            
        }

        
    }
}
