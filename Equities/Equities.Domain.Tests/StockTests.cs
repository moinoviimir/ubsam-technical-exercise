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
    }
}
