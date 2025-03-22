using Prediction.Domain.Entities;
using Prediction.Infrastructure.Adapters.Interfaces;

namespace Prediction.Infrastructure.Servicies
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithPredictionsAsync()
        {
            return await _customerRepository.GetCustomersWithPredictedOrdersAsync();
        }
    }
}
