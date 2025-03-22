using Prediction.Domain.Entities;
using Prediction.Infrastructure.Adapters.Interfaces;

namespace Prediction.Infrastructure.Servicies
{
    public class ProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
