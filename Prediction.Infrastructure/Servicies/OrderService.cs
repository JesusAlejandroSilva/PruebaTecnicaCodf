using Prediction.Application.DTOS;
using Prediction.Domain.Entities;
using Prediction.Infrastructure.Adapters.Interfaces;

namespace Prediction.Domain.Services
{

    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerAsync(int customerId)
        {
            return await _orderRepository.GetOrdersByCustomerIdAsync(customerId);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
            return order;
        }
    }
}
