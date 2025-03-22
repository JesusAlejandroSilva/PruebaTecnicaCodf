using Microsoft.EntityFrameworkCore;
using Prediction.Domain.Entities;
using Prediction.Infrastructure.Adapters.Interfaces;
using Prediction.Infrastructure.Context;

namespace Prediction.Infrastructure.Adapters.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PersistenceContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(PersistenceContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(PersistenceContext context) : base(context) { }

        public async Task<IEnumerable<Customer>> GetCustomersWithPredictedOrdersAsync()
        {
            return await _context.Customer
                .Include(c => c.Orders)
                .ToListAsync();
        }
    }

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(PersistenceContext context) : base(context) { }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.Order
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }
    }

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PersistenceContext context) : base(context) { }
    }

    public class ShipperRepository : GenericRepository<Shipper>, IShipperRepository
    {
        public ShipperRepository(PersistenceContext context) : base(context) { }
    }

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(PersistenceContext context) : base(context) { }
    }
}

