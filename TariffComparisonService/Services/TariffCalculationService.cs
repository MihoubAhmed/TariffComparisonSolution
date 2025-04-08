using TariffComparisonService.Models;

namespace TariffComparisonService.Services
{
    public class TariffCalculationService
    {
        private readonly IEnumerable<ITariffCalculationStrategy> _strategies;

        public TariffCalculationService(IEnumerable<ITariffCalculationStrategy> strategies)
        {
            _strategies = strategies;
        }

        public decimal CalculateAnnualCost(TariffProduct product, int consumption)
        {
            var strategy = _strategies.FirstOrDefault(s => s.SupportedTariffTypeId == product.Type.Id);

            if (strategy == null)
                throw new InvalidOperationException($"No calculation strategy found for tariff type {product.Type.Id}");

            return strategy.CalculateAnnualCost(product, consumption);
        }
    }
}
