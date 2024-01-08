using PoS.Data;
using WebApplication1.Models;

namespace PoS.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order GetById(string orderId)
        {
            return _dbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public Order GetByIdWithItems(string orderId)
        {
            return _dbContext.Orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.OrderId == orderId);
        }

        public void Create(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public void Update(Order order)
        {
            var existingOrder = _dbContext.Orders.Find(order.OrderId);

            if (existingOrder != null)
            {
                _dbContext.Entry(existingOrder).CurrentValues.SetValues(order);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Product not found.");
            }
        }
    }
}
