using WebApplication1.Models;

namespace PoS.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        public void Create(Order order);
    }
}
