using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffComparisonService.Models;
using TariffComparisonService.Services;

namespace TariffComparisonService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TariffController : ControllerBase
    {
        private readonly TariffCalculationService _tariffCalculationService;

        public TariffController(TariffCalculationService tariffCalculationService)
        {
            _tariffCalculationService = tariffCalculationService;
        }

        [HttpGet("compare")]
        public ActionResult<IEnumerable<CalculationResult>> CompareTariffs([FromQuery] int consumption)
        {
            if (consumption <= 0)
            {
                return BadRequest("Consumption must be greater than 0.");
            }

            var products = GetMockProducts();

            var results = products.Select(product => new CalculationResult
            {
                TariffName = product.Name,
                AnnualCost = _tariffCalculationService.CalculateAnnualCost(product, consumption)
            })
            .OrderBy(r => r.AnnualCost)
            .ToList();

            return Ok(results);
        }

        // Mocked Products
        private List<TariffProduct> GetMockProducts()
        {
            return new List<TariffProduct>
            {
                new TariffProduct
                {
                    Name = "Product A",
                    Type = new TariffType { Id = 1, Name = "Basic" },
                    BaseCost = 5,
                    AdditionalKwhCost = 22
                },
                new TariffProduct
                {
                    Name = "Product B",
                    Type = new TariffType { Id = 2, Name = "Packaged" },
                    BaseCost = 800,
                    IncludedKwh = 4000,
                    AdditionalKwhCost = 30
                }
            };
        }
    }
}
