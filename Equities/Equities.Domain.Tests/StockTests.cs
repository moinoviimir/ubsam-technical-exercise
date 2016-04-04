using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Equities.Domain.Tests
{
    [TestFixture]
    public class StockTests
    {
        [TestCase]
        public void CtorCorrectlyAssignsPrice()
        {
            var price = 1.0m;
            var sut = new Mock<Stock>(MockBehavior.Strict, price, 0);
            Assert.AreEqual(sut.Object.Price, price);
        }

        [TestCase]
        public void CtorCorrectlyAssignsQuantity()
        {
            var quantity = 1;
            var sut = new Mock<Stock>(MockBehavior.Strict, 1.0m, quantity);
            Assert.AreEqual(sut.Object.Quantity, quantity);
        }

        [TestCase]
        public void MarketValueIsZeroIfPriceIsZero()
        {
            var sut = new Mock<Stock>(MockBehavior.Strict, 0m, 5);
            Assert.AreEqual(0, sut.Object.MarketValue);
        }

        [TestCase]
        public void MarketValueIsZeroIfQuantityIsZero()
        {
            var sut = new Mock<Stock>(MockBehavior.Strict, 5.0m, 0);
            Assert.AreEqual(0, sut.Object.MarketValue);
        }

        [TestCase]
        public void MarketValueIsCorrectIfPriceIsNonzeroAndQuantityIsNonzero()
        {
            var sut = new Mock<Stock>(MockBehavior.Strict, 3.0m, 4);
            Assert.AreEqual(12, sut.Object.MarketValue);
        }
    }
}
