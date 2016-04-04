using System.Collections.Generic;
using System.Linq;
using Equities.Domain.Providers;
using Moq;
using NUnit.Framework;


namespace Equities.Domain.Tests
{
    [TestFixture]
    public class FundTests
    {
        private Mock<IStockNameProvider> _stockNameProviderMock;

        [SetUp]
        public void Setup()
        {
            _stockNameProviderMock = new Mock<IStockNameProvider>();
        }

        [TestCase]
        public void AddShouldAddStockToFund()
        {
            var sut = new Fund(_stockNameProviderMock.Object);
            var stockMock = new Mock<Stock>(MockBehavior.Strict, 0.0m, 0);

            sut.Add(stockMock.Object);

            var result = sut.GetStocks().FirstOrDefault();
            Assert.AreEqual(stockMock.Object, result);
        }

        [TestCase]
        public void NotAddingAnythingProducesEmptyResult()
        {
            var sut = new Fund(_stockNameProviderMock.Object);

            var result = sut.GetStocks().FirstOrDefault();

            Assert.IsNull(result);
        }

        [TestCase]
        public void GetStocksReturnsStocks()
        {
            var sut = new Fund(_stockNameProviderMock.Object);
            
            var list = new List<Stock>
            {
                new Mock<Stock>(MockBehavior.Strict, 1.0m, 1).Object,
                new Mock<Stock>(MockBehavior.Strict, 2.0m, 2).Object
            };
            
            list.ForEach(item => sut.Add(item));
            var result = sut.GetStocks();

            CollectionAssert.AreEquivalent(result, list);
        }

        [TestCase]
        public void AddingOneStockTwiceProducesAListWithADuplicate()
        {
            var sut = new Fund(_stockNameProviderMock.Object);
            var stock = new Mock<Stock>(MockBehavior.Strict, 3.0m, 3).Object;
            var list = new List<Stock> {stock, stock};

            list.ForEach(item => sut.Add(item));
            var result = sut.GetStocks();

            CollectionAssert.AreEquivalent(result, list);
        }
    }
}
