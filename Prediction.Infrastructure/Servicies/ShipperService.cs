using Prediction.Domain.Entities;
using Prediction.Infrastructure.Adapters.Interfaces;

namespace Prediction.Infrastructure.Servicies
{
    public class ShipperService
    {
        private readonly IGenericRepository<Shipper> _shipperRepository;

        public ShipperService(IGenericRepository<Shipper> shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }

        public async Task<IEnumerable<Shipper>> GetAllShippersAsync()
        {
            return await _shipperRepository.GetAllAsync();
        }
    }
}
