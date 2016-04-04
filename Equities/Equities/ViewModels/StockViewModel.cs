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
        public string StockType { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public decimal MarketValue { get; }

        public decimal TransactionCost { get; }

        public decimal StockWeight { get; }

        public bool IsInTheRed { get; }

        public StockViewModel(Stock stock)
        {
            Price = stock.Price;
            Quantity = stock.Quantity;
            MarketValue = stock.MarketValue;
            StockType = stock.StockType.ToString();
            Name = stock.Name;
            TransactionCost = stock.TransactionCost;
            StockWeight = stock.StockWeight;

            IsInTheRed = ShouldBeRed(stock);
        }

        private static bool ShouldBeRed(Stock stock)
        {
            var tolerance = stock.StockType == TypeOfStock.Bond ? 100000 : 200000;
            return stock.MarketValue < 0 || stock.TransactionCost > tolerance;
        }
    }
}
