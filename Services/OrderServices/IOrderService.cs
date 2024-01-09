using PoS.Services.GenericServices;
using WebApplication1.Models;
using PoS.Dtos.Order;
using PoS.Dtos.Payment;
using PoS.Dtos.OrderItem;

namespace PoS.Services.OrderServices
{
    public interface IOrderService
    {
        Order Create(CreateOrderDto createOrderDto);
        Order CreateFromBooking(CreateOrderDto createOrderDto);
        Order AddItemToOrder(string orderId, OrderItemDto newItemDto);
        Order RemoveItemFromOrder(string orderId, string orderItemId);
        Order ApplyDiscount(string orderId, string discountId);
        Order ApplyLoyaltyProgram(string orderId, string loyaltyProgramId);
        Order AddTip(string orderId, decimal tipAmount);
        Order ProcessPayment(string orderId, CreatePaymentDto createPaymentDto);
        OrderReceiptDto GetReceipt(string orderId);
    }
}