using WebApplication1.Models;

namespace PoS.Repositories.PaymentMethodRepository
{
    public interface IPaymentMethodRepository
    {
        PaymentMethod GetById(string paymentMethodId);
    }
}
