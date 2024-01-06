using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.PaymentServices;

public interface IPaymentService : IGenericService<Payment>
{
    // Additional Payment-specific methods, if needed
}