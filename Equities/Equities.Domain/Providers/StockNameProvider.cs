using System;
using System.Collections.Generic;

namespace Equities.Domain.Providers
{
    public class StockNameProvider : IStockNameProvider
    {
        private int currentBondQuantity = 0;
        private int currentEquityQuantity = 0;

        public virtual IEnumerable<Stock> CreateNames(IEnumerable<Stock> stocks)
        {
            int equityNumber = 1, bondNumber = 1;
            var result = new List<Stock>(stocks);

            foreach (var stock in result)
            {
                int number;
                switch (stock.StockType)
                {
                    case TypeOfStock.Equity:
                        number = equityNumber;
                        equityNumber++;
                        break;
                    case TypeOfStock.Bond:
                        number = bondNumber;
                        bondNumber++;
                        break;
                    default:
                        throw new InvalidOperationException("Unexpected StockType.");
                }

                stock.Name = String.Format("{0}{1}", stock.StockType, number);
            }
            return result;
        }

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
