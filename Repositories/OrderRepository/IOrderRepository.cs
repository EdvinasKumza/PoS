using WebApplication1.Models;

namespace PoS.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        void Create(Order order);
        void Update(Order order);
        Order GetById(string orderId);
        Order GetByIdWithItems(string orderId);
    }
}
