using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equities.Domain.Providers;
using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Equities.Domain.Tests
{
    [TestFixture]
    public class StockNameProviderTests
    {

        [TestCase]
        public void CreateNamesReturnsEmptyListWhenGivenAnEmptyList()
        {
            var sut = new StockNameProvider();
            var result = sut.CreateNames(new List<Stock>());
            CollectionAssert.IsEmpty(result);
        }

        [TestCase]
        public void CreateNamesReturnsAOneElementCollectionWhenGivenAOneElementCollection()
        {
            var sut = new StockNameProvider();
            var result = sut.CreateNames(new List<Stock> { new Equity(1.0m, 5) });
            Assert.IsTrue(result.Count() == 1);
        }

        [TestCase]
        public void CreateNamesReturnsAFiveElementCollectionWhenGivenAFiveElementCollectionOfDifferentTypes()
        {
            var sut = new StockNameProvider();
            var result = sut.CreateNames(new List<Stock>
            {
                new Equity(1.0m, 5),
                new Bond(2.0m, 5),
                new Equity(3.1m, 15),
                new Equity(2.2m, 1),
                new Equity(4.0m, 23)
            });
            Assert.IsTrue(result.Count() == 5);
        }

        [TestCase]
        public void CreateNamesCorrectlyAssignsNamesWhenGivenASingleEquity()
        {
            var sut = new StockNameProvider();
            var result = sut.CreateNames(new List<Stock> {new Equity(1.0m, 5)});
            Assert.IsTrue(result.First().Name == "Equity1");
        }

        [TestCase]
        public void CreateNamesCorrectlyAssignsNamesWhenGivenTwoEquities()
        {
            var sut = new StockNameProvider();
            var list = new List<Stock>
            {
                new Equity(1.0m, 5),
                new Equity(2.0m, 10)
            };
            var result = sut.CreateNames(list);
            Assert.IsTrue(result.First().Name == "Equity1");
            Assert.IsTrue(result.ElementAt(1).Name == "Equity2");
        }

        [TestCase]
        public void CreateNamesCorrectlyAssignsNamesWhenGivenABondAndAnEquity()
        {
            var sut = new StockNameProvider();
            var list = new List<Stock>
            {
                new Equity(1.0m, 3),
                new Bond(2.2m, 1)
            };

            var result = sut.CreateNames(list);
            Assert.IsTrue(result.First().Name == "Equity1");
            Assert.IsTrue(result.ElementAt(1).Name == "Bond1");
        }

        [TestCase]
        public void CreateNamesCorrectlyAssignsNamesWhenGivenSeveralBondsAndEquitiesAtOnce()
        {
            var sut = new StockNameProvider();
            var list = new List<Stock>
            {
                new Equity(1.0m, 2),
                new Equity(2.0m, 2),
                new Bond(3.0m, 3),
                new Equity(4.0m, 5),
                new Bond(10.0m, 11)
            };

            var result = sut.CreateNames(list);
            // we enumerate over the same list here, but it makes little difference performance wise
            Assert.IsTrue(result.First().Name == "Equity1");
            Assert.IsTrue(result.ElementAt(1).Name == "Equity2");
            Assert.IsTrue(result.ElementAt(2).Name == "Bond1");
            Assert.IsTrue(result.ElementAt(3).Name == "Equity3");
            Assert.IsTrue(result.ElementAt(4).Name == "Bond2");
        }


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
