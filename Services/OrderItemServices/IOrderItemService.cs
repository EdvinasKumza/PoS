using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.OrderItemServices;

public interface IOrderItemService : IGenericService<OrderItem>
{
    // Additional OrderItem-specific methods, if needed
}