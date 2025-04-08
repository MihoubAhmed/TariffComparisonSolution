using TariffComparisonService.Models;

namespace TariffComparisonService.Services
{
    public class BasicTariffCalculationService : ITariffCalculationStrategy
    {
        public int SupportedTariffTypeId => 1; // 1 = Basic

        public decimal CalculateAnnualCost(TariffProduct product, int consumption)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            decimal baseCostPerYear = product.BaseCost * 12;
            decimal consumptionCost = consumption * (product.AdditionalKwhCost.GetValueOrDefault() / 100m);
            return baseCostPerYear + consumptionCost;
        }
    }

}
