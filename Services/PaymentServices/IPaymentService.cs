using PoS.Services.GenericServices;
using WebApplication1.Models;
using PoS.Dtos.Payment;

namespace PoS.Services.PaymentServices;

public interface IPaymentService
{
    Payment ProcessPayment(Order order, CreatePaymentDto createPaymentDto);
}