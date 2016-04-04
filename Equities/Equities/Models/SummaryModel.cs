using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equities.Models
{
    public sealed class SummaryModel
    {
        public string Name { get; set; }
        public int TotalNumber { get; set; }
        public decimal TotalMarketValue { get; set; }
        public decimal TotalStockWeight { get; set; }
    }
}
