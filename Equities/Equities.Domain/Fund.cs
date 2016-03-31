using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equities.Domain
{
    public class Fund
    {
        private readonly IList<Stock> _registry;

        public Fund()
        {
            _registry = new List<Stock>();
        }

        public void Add(Stock item)
        {
            _registry.Add(item);
        }

        public bool Contains(Stock item)
        {
            return _registry.Contains(item);
        }


    }
}
