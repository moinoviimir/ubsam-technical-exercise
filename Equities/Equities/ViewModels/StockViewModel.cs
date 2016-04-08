using Equities.Domain;

namespace Equities.ViewModels
{
    /// <summary>
    /// The ViewModel in charge of displaying a Stock business object.
    /// </summary>
    public sealed class StockViewModel
    {
        public string StockType { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public decimal MarketValue { get; }

        public decimal TransactionCost { get; }

        public decimal StockWeight { get; }

        /// <summary>
        /// Determines if the Stock is potentially unprofitable.
        /// </summary>
        /// <remarks>
        /// Used by the UI to colour Names in the grid.
        /// </remarks>
        public bool IsInTheRed { get; }

        /// <summary>
        /// Creates a new instance of the StockViewModel class, based on a provided Stock.
        /// </summary>
        /// <param name="stock">The Stock.</param>
        /// <remarks>
        /// This constructor couples tightly to a Stock domain object, but I couldn't bring myself to either writing mapping or introducing AutoMapper for this trivial task.
        /// </remarks>
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

        /// <summary>
        /// Determines if the Stock is potentially unprofitable.
        /// </summary>
        /// <param name="stock">The Stock in question.</param>
        /// <returns>True for an unprofitable stock, false otherwise.</returns>
        /// <remarks>
        /// An argument could be made for splitting this off into a separate entity. Its responsibilities are arguably distinct enough.
        /// I do not have a strong opinion on the subject, and, although I do lean towards splitting it off, I'm keeping it as it is because of time constraints.
        /// </remarks>
        private static bool ShouldBeRed(Stock stock)
        {
            var tolerance = stock.StockType == TypeOfStock.Bond ? 100000 : 200000;
            return stock.MarketValue < 0 || stock.TransactionCost > tolerance;
        }
    }
}
