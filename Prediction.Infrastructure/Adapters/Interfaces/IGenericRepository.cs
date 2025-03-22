using Prediction.Domain.Entities;

namespace Prediction.Infrastructure.Adapters.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomersWithPredictedOrdersAsync();
    }

    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
    }

    public interface IEmployeeRepository : IGenericRepository<Employee> { }
    public interface IShipperRepository : IGenericRepository<Shipper> { }
    public interface IProductRepository : IGenericRepository<Product> { }
}

