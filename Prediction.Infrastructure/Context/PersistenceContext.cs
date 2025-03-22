using Microsoft.EntityFrameworkCore;
using Prediction.Domain.Entities;

namespace Prediction.Infrastructure.Context
{
    public class PersistenceContext:DbContext
    {
        public PersistenceContext(DbContextOptions<PersistenceContext> op): base(op)
        {

            
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });

           modelBuilder.Entity<Order>()
            .Property(o => o.Freight)
            .HasColumnType("decimal(18,2)"); 

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.Discount)
                .HasColumnType("decimal(4,3)");

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId }); 

            base.OnModelCreating(modelBuilder);
        }

    }
}
