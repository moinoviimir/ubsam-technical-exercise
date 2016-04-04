using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Equities.Domain.Tests
{
    [TestFixture]
    public class BondTests
    {
        [TestCase]
        public void NewBondHasCorrectStockType()
        {
            var sut = new Bond(1.0m, 1);
            Assert.AreEqual(TypeOfStock.Bond, sut.StockType);
        }

        [TestCase]
        public void BondTransactionCostIsZeroIfZeroQuantityBought()
        {
            var sut = new Bond(1.0m, 0);
            Assert.AreEqual(0, sut.TransactionCost);
        }

        [TestCase]
        public void BondTransactionCostIsZeroIfStockCostsZero()
        {
            var sut = new Bond(0m, 10);
            Assert.AreEqual(0, sut.TransactionCost);
        }

        [TestCase]
        public void BondTransactionCostIsCorrectForNonzeroQuantityAndCost()
        {
            var sut = new Bond(10.0m, 5);
            Assert.AreEqual(1, sut.TransactionCost);
        }
    }
}
