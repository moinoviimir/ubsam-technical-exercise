using System;
using System.Collections.Generic;
using System.Linq;
using Equities.Builders;
using Equities.Domain;
using Equities.Domain.Providers;
using NUnit.Framework;

namespace Equities.UI.Tests
{
    [TestFixture]
    public class SummaryBuilderTests
    {
        private Func<IEnumerable<Stock>> getStocksFunc;
        private IEnumerable<Stock> emptyStockSet = new List<Stock>();
        private IEnumerable<Stock> arbitraryStockSet = new List<Stock> {new Equity(10.0m, 5), new Bond(7.0m, 15)};

        private IEnumerable<Stock> baseTestingStockSet = new List<Stock>
        {
            new Equity(10.0m, 1),
            new Bond(10.0m, 3),
            new Equity(3.0m, 6),
            new Bond(3.0m, 10),
            new Equity(6.0m, 2)
        };

        [SetUp]
        public void Setup()
        {
            getStocksFunc = () => new List<Stock>();
        }

        /// <summary>
        /// We've got to use this, because we're testing computations done by the Fund internally.
        /// </summary>
        /// <param name="stocks">Stocks.</param>
        /// <returns>A getter for updated Stocks.</returns>
        private Func<IEnumerable<Stock>> SetupFund(IEnumerable<Stock> stocks)
        {
            var fund = new FundFactory().Create();
            foreach (var stock in stocks)
                fund.Add(stock);

            return fund.GetStocks;
        }

        [TestCase]
        public void OnlyUsingBuildWithEmptyListReturnsEmptyList()
        {
            getStocksFunc = () => emptyStockSet;
            var sut = new SummaryBuilder(getStocksFunc);
            CollectionAssert.IsEmpty(sut.Build());
        }

        [TestCase]
        public void OnlyUsingBuildWithNonEmptyListReturnsEmptyList()
        {
            getStocksFunc = () => arbitraryStockSet;
            var sut = new SummaryBuilder(getStocksFunc);
            CollectionAssert.IsEmpty(sut.Build());
        }

        [TestCase]
        public void BuildWithOnlyEquitiesReturnsEmptyListForGivenEmptyList()
        {
            getStocksFunc = () => emptyStockSet;
            var sut = new SummaryBuilder(getStocksFunc);
            CollectionAssert.IsEmpty(sut.WithEquities().Build());
        }

        [TestCase]
        public void BuildWithOnlyBondsReturnsEmptyListForGivenEmptyList()
        {
            getStocksFunc = () => emptyStockSet;
            var sut = new SummaryBuilder(getStocksFunc);
            CollectionAssert.IsEmpty(sut.WithBonds().Build());
        }

        [TestCase]
        public void BuildWithOnlyTotalReturnsEmptyListForGivenEmptyList()
        {
            getStocksFunc = () => emptyStockSet;
            var sut = new SummaryBuilder(getStocksFunc);
            CollectionAssert.IsEmpty(sut.WithTotal().Build());
        }

        [TestCase]
        public void BuildWithOnlyEquitiesAndBondsReturnsEmptyListForGivenEmptyList()
        {
            getStocksFunc = () => emptyStockSet;
            var sut = new SummaryBuilder(getStocksFunc);
            CollectionAssert.IsEmpty(
                sut.WithEquities().WithBonds().Build());
        }

        [TestCase]
        public void BuildWithEverythingReturnsEmptyListForGivenEmptyList()
        {
            getStocksFunc = () => emptyStockSet;
            var sut = new SummaryBuilder(getStocksFunc);
            CollectionAssert.IsEmpty(
                sut.WithEquities().WithBonds().WithTotal().Build());
        }

        [TestCase]
        public void BuildWithEquitiesReturnsAListOfOne()
        {
            getStocksFunc = () => arbitraryStockSet;
            var sut = new SummaryBuilder(getStocksFunc);
            Assert.AreEqual(1, sut.WithEquities().Build().Count());
        }

        [TestCase]
        public void BuildWithEquitiesReturnsCorrectSummaryModel()
        {
            getStocksFunc = SetupFund(baseTestingStockSet);

            var sut = new SummaryBuilder(getStocksFunc);
            var result = sut.WithEquities().Build().First();
            Assert.AreEqual("Equities", result.Name);
            Assert.AreEqual(3, result.TotalNumber);
            Assert.AreEqual(0.4m, result.TotalStockWeight);
        }

        [TestCase]
        public void BuildWithBondsReturnsCorrectSummaryModel()
        {
            getStocksFunc = SetupFund(baseTestingStockSet);

            var sut = new SummaryBuilder(getStocksFunc);
            var result = sut.WithBonds().Build().First();
            Assert.AreEqual("Bonds", result.Name);
            Assert.AreEqual(2, result.TotalNumber);
            Assert.AreEqual(0.6m, result.TotalStockWeight);
        }

        [TestCase]
        public void BuildWithEquitiesAndBondsReturnsATwoEntryList()
        {
            getStocksFunc = SetupFund(baseTestingStockSet);
            var sut = new SummaryBuilder(getStocksFunc);
            Assert.AreEqual(2, sut.WithEquities().WithBonds().Build().Count());
        }

        [TestCase]
        public void BuildWithEquitiesAndBondsReturnsCorrectSummaryModel()
        {
            getStocksFunc = SetupFund(baseTestingStockSet);

            var sut = new SummaryBuilder(getStocksFunc);
            var result = sut.WithEquities().WithBonds().Build();
            var equities = result.First();
            Assert.AreEqual(0.4m, equities.TotalStockWeight);
            var bonds = result.ElementAt(1);
            Assert.AreEqual(0.6m, bonds.TotalStockWeight);
        }

        [TestCase]
        public void BuildWithEquitiesBondsAndTotalReturnsAThreeEntryList()
        {
            getStocksFunc = SetupFund(baseTestingStockSet);

            var sut = new SummaryBuilder(getStocksFunc);
            Assert.AreEqual(3, sut.WithEquities().WithBonds().WithTotal().Build().Count());
        }

        [TestCase]
        public void BuildWithEquitiesBondsAndTotalReturnsCorrectSummaryModel()
        {
            getStocksFunc = SetupFund(baseTestingStockSet);

            var sut = new SummaryBuilder(getStocksFunc);
            var result = sut.WithEquities().WithBonds().WithTotal().Build();
            var equities = result.First();
            Assert.AreEqual(0.4m, equities.TotalStockWeight);
            var bonds = result.ElementAt(1);
            Assert.AreEqual(0.6m, bonds.TotalStockWeight);
            var total = result.ElementAt(2);
            Assert.AreEqual(1.0m, total.TotalStockWeight);
        }
    }
}
