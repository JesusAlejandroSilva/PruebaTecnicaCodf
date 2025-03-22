using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prediction.Infrastructure.Servicies;

namespace SaleDataPrediction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly ShipperService _shipperService;

        public ShippersController(ShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        [HttpGet]
        public async Task<IActionResult> GetShippers()
        {
            var shippers = await _shipperService.GetAllShippersAsync();
            return Ok(shippers);
        }
    }
}
