using System.Collections.Generic;
using System.Linq;
using Equities.Domain.Providers;
using Equities.Domain.Providers.Interfaces;

namespace Equities.Domain
{
    public sealed class Fund
    {
        private IEnumerable<Stock> _registry;
        private readonly IStockNameProvider _stockNameProvider;
        private readonly IStockWeightProvider _stockWeightProvider;

        public Fund(IStockNameProvider stockNameProvider, IStockWeightProvider stockWeightProvider)
        {
            _stockNameProvider = stockNameProvider;
            _stockWeightProvider = stockWeightProvider;
            _registry = new List<Stock>();
        }

        public void Add(Stock item)
        {
            var name = _stockNameProvider.CreateNewStockName(item);
            // we might want to get fancy here and create a copy of the Stock with a new name
            // this would happen all but immediately if we were to choose to have a Stock belong to multiple Funds
            item.Name = name;
            _registry = _registry.Concat(new List<Stock> { item });
            _stockWeightProvider.UpdateStockWeights(_registry);
        }

        public bool Contains(Stock item)
        {
            return _registry.Contains(item);
        }

        public IEnumerable<Stock> GetStocks()
        {
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var item in _registry)
                // yield here because financial data can be notoriously large, 
                // and lazily iterating over it with significant overhead for small collections
                // might be justified if ever we were to meet a truly large one
                yield return item;   
        }
    }
}
