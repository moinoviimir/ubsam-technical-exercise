using Equities.Domain;
using Equities.Infrastructure;
using Equities.Models;
using NUnit.Framework;

namespace Equities.UI.Tests.Models
{
    [TestFixture]
    public class StockInputModelTests
    {
        [TestCase]
        public void CtorThrowsOnInvalidPrice()
        {
            Assert.Throws<ModelValidationException>(
                () => new StockInputModel("price", "10", TypeOfStock.Equity.ToString()));
        }

        [TestCase]
        public void CtorThrowsOnInvalidQuantity()
        {
            Assert.Throws<ModelValidationException>(
                () => new StockInputModel("10,0", "quantity", TypeOfStock.Equity.ToString()));
        }

        [TestCase]
        public void CtorThrowsOnInvalidStockType()
        {
            Assert.Throws<ModelValidationException>(
                () => new StockInputModel("10,0", "10", "type"));
        }

        [TestCase]
        public void AsStockReturnsNewBondForEquityType()
        {
            var sut = new StockInputModel("10,0", "10", "Equity");
            Assert.IsInstanceOf(typeof(Equity), sut.AsStock());
        }

        [TestCase]
        public void AsStockReturnsNewBondForBondType()
        {
            var sut = new StockInputModel("10,0", "10", "Bond");
            Assert.IsInstanceOf(typeof(Bond), sut.AsStock());
        }
    }
}
