using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Equities.Domain.Tests
{
    [TestFixture]
    public class EquityTests
    {
        [TestCase]
        public void EquityHasCorrectStockType()
        {
            var sut = new Equity(2.0m, 2);
            Assert.AreEqual(TypeOfStock.Equity, sut.StockType);
        }

        [TestCase]
        public void EquityTransactionCostIsZeroIfZeroQuantityBought()
        {
            var sut = new Equity(1.0m, 0);
            Assert.AreEqual(0, sut.TransactionCost);
        }

        [TestCase]
        public void EquityTransactionCostIsZeroIfStockCostsZero()
        {
            var sut = new Equity(0m, 10);
            Assert.AreEqual(0, sut.TransactionCost);
        }

        [TestCase]
        public void EquityTransactionCostIsCorrectForNonzeroQuantityAndCost()
        {
            var sut = new Equity(10.0m, 20);
            Assert.AreEqual(1, sut.TransactionCost);
        }
    }
}
