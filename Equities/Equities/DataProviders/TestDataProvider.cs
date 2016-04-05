using Equities.Domain;
using Equities.Domain.Providers;

namespace Equities.DataProviders
{
    /// <summary>
    /// Sets up a default Fund that will be used as seed data for the app.
    /// Acts as the datasource.
    /// </summary>
    public sealed class TestDataProvider
    {
        public static Fund CreateTestFund()
        {
            var fund = new FundFactory().Create();
            var bond = new Bond(1000.0m, 5000);
            var equity = new Equity(25000.0m, 400);
            var bond2 = new Bond(3500.0m, 600);
            var bond3 = new Bond(1000.0m, 10000);
            fund.Add(bond);
            fund.Add(equity);
            fund.Add(bond2);
            fund.Add(bond3);

            return fund;
        }
    }
}
