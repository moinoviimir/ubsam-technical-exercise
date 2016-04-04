using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equities.Domain;

namespace Equities.ViewModels
{
    public class StockViewModel
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public StockViewModel(Stock stock)
        {
            Price = stock.Price;
            Quantity = stock.Quantity;
        }
    }
}
