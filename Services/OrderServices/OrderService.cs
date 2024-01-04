using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.OrderServices;

public class OrderService : GenericService<Order>, IOrderService
{
    public OrderService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}