using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using Equities.Domain;
using Equities.Infrastructure;
using Equities.Models;

namespace Equities.ViewModels
{
    public sealed class AddStockViewModel : NotifiableObject
    {
        private string _price;
        public string Price
        {
            get { return _price;}
            set
            {
                _price = value;
                _addCommand.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(Price));
            }
        }

        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                _addCommand.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public string StockType {get; set; }

        public ICollectionView StockTypes { get; }

        private readonly DelegateCommand _addCommand;
        public ICommand AddCommand => _addCommand;

        private Action<StockInputModel> _addStockAction;

        public AddStockViewModel(Action<StockInputModel> addStockAction)
        {
            StockTypes = new ListCollectionView(new List<string> { TypeOfStock.Equity.ToString(), TypeOfStock.Bond.ToString() });
            _addCommand = new DelegateCommand(o => AddNewStock(), o => IsModelValid());
            _addStockAction = addStockAction;
            StockType = TypeOfStock.Equity.ToString();
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

        private void AddNewStock()
        {
            try
            {
                var inputModel = new StockInputModel(Price, Quantity, StockType);
                _addStockAction(inputModel);
            }
            catch (ModelValidationException mex)
            {
                // log it and rethrow, eventually getting across to the exception boundary that would generate a user-friendly exception
                // having it reach the user as a suitable dialog window explaining the problem
            }
        }

        
    }
}
