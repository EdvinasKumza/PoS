using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.PaymentMethodServices;

public interface IPaymentMethodService : IGenericService<PaymentMethod>
{
    // Additional PaymentMethod-specific methods, if needed
}