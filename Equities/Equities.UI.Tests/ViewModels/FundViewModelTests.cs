using System.Linq;
using Equities.Domain;
using Equities.Domain.Providers;
using Equities.Models;
using Equities.ViewModels;
using NUnit.Framework;

namespace Equities.UI.Tests.ViewModels
{
    [TestFixture]
    public class FundViewModelTests
    {
        [TestCase]
        public void AddStockUpdatesCollectionWithTheAddedStock()
        {
            var fund = new FundFactory().Create();
            fund.Add(new Bond(10.0m, 5));
            var sut = new FundViewModel(fund);
            var oldCount = sut.Stocks.Cast<StockViewModel>().Count();
            sut.AddStock(new StockInputModel("15,0", "5", "Bond"));
            Assert.AreEqual(oldCount + 1, sut.Stocks.Cast<StockViewModel>().Count());
        }
    }
}
