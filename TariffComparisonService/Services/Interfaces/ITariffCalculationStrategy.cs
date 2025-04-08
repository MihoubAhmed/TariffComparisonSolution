using TariffComparisonService.Models;
namespace TariffComparisonService.Services.Interfaces
{
    public interface ITariffCalculationStrategy
    {
        int SupportedTariffTypeId { get; }
        decimal CalculateAnnualCost(TariffProduct product, int consumption);
    }

}
