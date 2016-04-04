using System;
using System.Collections.Generic;
using Equities.Domain.Providers;
using NUnit.Framework;

namespace Equities.Domain.Tests.Providers
{
    [TestFixture]
    public class StockWeightProviderTests
    {
        [TestCase]
        public void UpdateStockWeightsThrowsOnNullStockList()
        {
            var sut = new StockWeightProvider();
            Assert.Throws<ArgumentNullException>(() => sut.UpdateStockWeights(null));
        }

        [TestCase]
        public void UpdateStockWeightsDoesNotModifyAnEmptyStockList()
        {
            var sut = new StockWeightProvider();
            var list = new List<Stock>();
            sut.UpdateStockWeights(list);
            Assert.IsEmpty(list);
        }

        [TestCase]
        public void UpdateStockWeightsIsCorrectForOnlyOneStockInList()
        {
            var sut = new StockWeightProvider();
            var bond = new Bond(10.0m, 5);
            var list = new List<Stock> {bond};
            sut.UpdateStockWeights(list);
            Assert.AreEqual(1.0m, bond.StockWeight);
        }

        [TestCase]
        public void UpdateStockWeightsIsCorrectForThreeTotalStocksOfEitherTypeInList()
        {
            var sut = new StockWeightProvider();
            var bond1 = new Bond(10.0m, 5);
            var bond2 = new Bond(3.0m, 10);
            var equity1 = new Equity(2.5m, 8);
            sut.UpdateStockWeights(new List<Stock> {bond1, bond2, equity1});
            Assert.AreEqual(0.5m, bond1.StockWeight);
            Assert.AreEqual(0.3m, bond2.StockWeight);
            Assert.AreEqual(0.2m, equity1.StockWeight);
        }
    }
}
