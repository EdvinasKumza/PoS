using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using WebApplication1.Models;


namespace PoS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=PoSDB.db");
            }
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<GiftCard> GiftCards { get; set; }
        public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<GiftCardActivation> GiftCardActivations { get; set; }
        public DbSet<GiftCardTransaction> GiftCardTransactions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<InventoryOrder> InventoryOrders { get; set; }
        public DbSet<InventoryOrderItem> InventoryOrderItems { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<CustomerLoyalty> CustomerLoyalties { get; set; }
    }
}
