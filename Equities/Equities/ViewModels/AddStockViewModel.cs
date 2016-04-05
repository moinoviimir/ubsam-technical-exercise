using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Equities.Domain;

namespace Equities.ViewModels
{
    public sealed class AddStockViewModel
    {
        private string _price;
        private string _quantity;

        public string Price
        {
            get { return _price;}
            set
            {
                
            }
        }

        public string Quantity
        {
            get { return _quantity; }
            set
            {
                
            }
        }

        public string StockType {get; set; }

        public bool CanAdd { get; private set; }

        public ICollectionView StockTypes { get; }

        public string ErrorTooltip { get; private set; }


        public AddStockViewModel()
        {
            StockTypes = new ListCollectionView(new List<string> { TypeOfStock.Equity.ToString(), TypeOfStock.Bond.ToString() });
        }

        private void ValidateModel()
        {
            decimal tempDecimal;
            var isPriceValid = Decimal.TryParse(_price, out tempDecimal);

            int tempQuantity;
            var isQuantityValid = Int32.TryParse(_quantity, out tempQuantity);

            CanAdd = isPriceValid && isQuantityValid;
            if (!isPriceValid)
                ErrorTooltip = "Price is expected to be a decimal number";
            else if (!isQuantityValid)
                ErrorTooltip = "Quantity is expected to be an integer";
        }
    }
}
