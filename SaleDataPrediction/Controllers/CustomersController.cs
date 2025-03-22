using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prediction.Infrastructure.Servicies;

namespace SaleDataPrediction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("last-order")]
        public async Task<IActionResult> GetCustomersWithOrderPrediction()
        {
            var customers = await _customerService.GetCustomersWithPredictionsAsync();
            return Ok(customers);
        }
    }

}
