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
    }
}
