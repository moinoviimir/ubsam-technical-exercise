using System;
using Equities.Domain.Providers;
using NUnit.Framework;

namespace Equities.Domain.Tests.Providers
{
    [TestFixture]
    public class StockNameProviderTests
    {
        [TestCase]
        public void NameNewStockThrowsOnNullStock()
        {
            var sut = new StockNameProvider();
            Assert.Throws<ArgumentNullException>(() => sut.CreateNewStockName(null));
        }

        [TestCase]
        public void NameNewStockReturnsCorrectNameForFirstAddedEquity()
        {
            var sut = new StockNameProvider();
            var equity = new Equity(1.0m, 5);
            var name = sut.CreateNewStockName(equity);
            Assert.AreEqual("Equity1", name);
        }

        [TestCase]
        public void NameNewStockReturnsCorrectNameForFirstAddedBond()
        {
            var sut = new StockNameProvider();
            var bond = new Bond(1.0m, 2);
            var name = sut.CreateNewStockName(bond);
            Assert.AreEqual("Bond1", name);
        }

        [TestCase]
        public void NameNewStockReturnsCorrectNameForSecondAddedEquity()
        {
            var sut = new StockNameProvider();
            sut.CreateNewStockName(new Equity(1.0m, 1));
            var equity = new Equity(1.5m, 2);
            var name = sut.CreateNewStockName(equity);

            Assert.AreEqual("Equity2", name);
        }

        [TestCase]
        public void NameNewStockReturnsCorrectNameForThirdAddedEquityAfterABondHasBeenAddedAswell()
        {
            var sut = new StockNameProvider();
            sut.CreateNewStockName(new Equity(1.0m, 2));
            sut.CreateNewStockName(new Equity(9.0m, 2));
            sut.CreateNewStockName(new Bond(2.0m, 1));
            var equity = new Equity(5.0m, 2);
            var name = sut.CreateNewStockName(equity);
            Assert.AreEqual("Equity3", name);
        }
    }
}
