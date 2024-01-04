using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.OrderServices;

public interface IOrderService : IGenericService<Order>
{ 
    // Additional Order-specific methods, if needed
}