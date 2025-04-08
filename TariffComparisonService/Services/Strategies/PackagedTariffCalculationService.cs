using TariffComparisonService.Models;
using TariffComparisonService.Services.Interfaces;

namespace TariffComparisonService.Services.Strategies
{
    public class PackagedTariffCalculationService : ITariffCalculationStrategy
    {
        public int SupportedTariffTypeId => 2; // 2 = Packaged

        public decimal CalculateAnnualCost(TariffProduct product, int consumption)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (consumption <= product.IncludedKwh)
                return product.BaseCost;

            var additionalConsumption = consumption - product.IncludedKwh.GetValueOrDefault();
            var additionalCost = additionalConsumption * (product.AdditionalKwhCost.GetValueOrDefault() / 100m);

            return product.BaseCost + additionalCost;
        }
    }
}
