using PoS.Services.GenericServices;
using WebApplication1.Models;
using PoS.Dtos.Order;
using PoS.Dtos.OrderItem;

namespace PoS.Services.OrderServices
{
    public interface IOrderService
    {
        Order Create(CreateOrderDto createOrderDto);
        Order AddItemToOrder(string orderId, OrderItemDto newItemDto);
        Order RemoveItemFromOrder(string orderId, string orderItemId);
    }
}