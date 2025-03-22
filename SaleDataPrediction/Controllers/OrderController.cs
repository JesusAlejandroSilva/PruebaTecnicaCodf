using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prediction.Application.DTOS;
using Prediction.Domain.Entities;
using Prediction.Domain.Services;

namespace SaleDataPrediction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomer(int customerId)
        {
            var orders = await _orderService.GetOrdersByCustomerAsync(customerId);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO orderRequest)
        {
            if (orderRequest == null || orderRequest.OrderDetails == null || !orderRequest.OrderDetails.Any())
                return BadRequest("Invalid order request");

            var order = new Order
            {
                CustomerId = orderRequest.CustomerId,
                EmployeeId = orderRequest.EmployeeId,
                OrderDate = orderRequest.OrderDate,
                RequiredDate = orderRequest.RequiredDate,
                ShippedDate = orderRequest.ShippedDate,
                ShipperId = orderRequest.ShipperId,
                Freight = orderRequest.Freight,
                ShipName = orderRequest.ShipName!,
                ShipAddress = orderRequest.ShipAddress!,
                ShipCity = orderRequest.ShipCity!,
                ShipCountry = orderRequest.ShipCountry!,
                OrderDetails = orderRequest.OrderDetails.Select(od => new OrderDetail
                {
                   ProductId = od.ProductId,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                 }).ToList()
            };

            var createdOrder = await _orderService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrdersByCustomer), new { customerId = createdOrder.CustomerId }, createdOrder);
        }
    }
}
