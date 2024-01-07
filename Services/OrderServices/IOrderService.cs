using PoS.Services.GenericServices;
using WebApplication1.Models;
using PoS.Dtos.Order;

namespace PoS.Services.OrderServices
{
    public interface IOrderService
    {
        Order Create(CreateOrderDto createOrderDto);
    }
}