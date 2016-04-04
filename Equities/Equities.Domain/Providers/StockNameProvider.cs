using System;
using System.Collections.Generic;

namespace Equities.Domain.Providers
{
    public class StockNameProvider : IStockNameProvider
    {
        private int currentBondQuantity = 0;
        private int currentEquityQuantity = 0;

        public string CreateNewStockName(Stock stock)
        {
            if (stock == null)
                throw new ArgumentNullException(nameof(stock));

            int number;
            switch (stock.StockType)
            {
                case TypeOfStock.Bond:
                    currentBondQuantity++;
                    number = currentBondQuantity;
                    break;
                case TypeOfStock.Equity:
                    currentEquityQuantity++;
                    number = currentEquityQuantity;
                    break;
                default:
                    throw new InvalidOperationException("Unexpected StockType");

            }
            return String.Format("{0}{1}", stock.StockType, number);
        }
    }
}
