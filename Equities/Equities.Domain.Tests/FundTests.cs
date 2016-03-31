using NUnit.Framework;

namespace Equities.Domain.Tests
{
    [TestFixture]
    public class FundTests
    {
        [TestCase]
        public void AddShouldAddStockToFund()
        {
            var fund = new Fund();
            var equity = new Equity(0.0m, 0);
            fund.Add(equity);

            var result = fund.Contains(equity);
            Assert.IsTrue(result);
        }
        
        
    }
}
