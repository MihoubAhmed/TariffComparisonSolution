namespace TariffComparisonService.Models
{
    public class TariffProduct
    {
        public string Name { get; set; }
        public TariffType Type { get; set; }
        public decimal BaseCost { get; set; }
        public decimal? AdditionalKwhCost { get; set; }
        public int? IncludedKwh { get; set; }
    }
}
