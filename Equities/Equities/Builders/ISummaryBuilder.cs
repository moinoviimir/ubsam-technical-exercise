using System.Collections.Generic;
using Equities.Models;

namespace Equities.Builders
{
    public interface ISummaryBuilder
    {
        IEnumerable<SummaryModel> Build();
        ISummaryBuilder WithBonds();
        ISummaryBuilder WithEquities();
        ISummaryBuilder WithTotal();
    }
}