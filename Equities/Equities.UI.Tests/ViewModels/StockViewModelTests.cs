using Equities.Domain;
using Equities.ViewModels;
using Moq;
using NUnit.Framework;

namespace Equities.UI.Tests.ViewModels
{
    [TestFixture]
    public class StockViewModelTests
    {
        [TestCase]
        public void IsInTheRedIsTrueForStockWithMarketValueLessThanZero()
        {
            var stock = new Mock<Stock>(MockBehavior.Loose, 10.0m, -10);
            var sut = new StockViewModel(stock.Object);
            Assert.IsTrue(sut.IsInTheRed);
        }

        [TestCase]
        public void IsInTheRedIsTrueForBondWithTransactionCostOverAHundredThousand()
        {
            var sut = new StockViewModel(new Bond(10000.0m, 10000));
            Assert.IsTrue(sut.IsInTheRed);
        }

        [TestCase]
        public void IsInTheRedIsTrueForEquityWithTransactionCostOverTwoHundredThousand()
        {
            var sut = new StockViewModel(new Equity(10000.0m, 10000));
            Assert.IsTrue(sut.IsInTheRed);
        }

        [TestCase]
        public void IsInTheRedIsFalseForARegularBond()
        {
            var sut = new StockViewModel(new Bond(10.0m, 5));
            Assert.IsFalse(sut.IsInTheRed);
        }

        [TestCase]
        public void IsInTheRedIsFalseForARegularEquity()
        {
            var sut = new StockViewModel(new Equity(10.0m, 5));
            Assert.IsFalse(sut.IsInTheRed);
        }
    }
}
