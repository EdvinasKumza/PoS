using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.OrderItemServices;

public class OrderItemService : GenericService<OrderItem>, IOrderItemService
{
    public OrderItemService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}