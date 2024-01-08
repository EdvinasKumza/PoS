using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;
using PoS.Repositories.OrderRepository;
using PoS.Repositories.PaymentRepository;
using PoS.Repositories.PaymentMethodRepository;
using PoS.Dtos.Payment;

namespace PoS.Services.PaymentServices;

public class PaymentService : IPaymentService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPaymentMethodRepository _paymentMethodRepository;

    public PaymentService(IPaymentRepository paymentRepository, IOrderRepository orderRepository, IPaymentMethodRepository paymentMethodRepository)
    {
        _orderRepository = orderRepository;
        _paymentRepository = paymentRepository;
        _paymentMethodRepository = paymentMethodRepository;
    } 

    public Payment ProcessPayment(Order order, CreatePaymentDto createPaymentDto)
    {
        var paymentMethod = _paymentMethodRepository.GetById(createPaymentDto.PaymentMethodId);

        if (paymentMethod == null)
        {
            throw new InvalidOperationException("Payment method not found.");

        }

        var payment = new Payment {
            OrderId = order.OrderId,
            Amount = order.TotalAmount,
            PaymentMethodId = paymentMethod.PaymentMethodId,
        };

        _paymentRepository.Create(payment);

        return payment;

    }
}