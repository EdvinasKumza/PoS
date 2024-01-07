using WebApplication1.Models;

namespace PoS.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        public void Create(Order order);
        public void Update(Order order);
        public Order GetById(string orderId);
    }
}
