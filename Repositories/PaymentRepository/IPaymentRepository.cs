using WebApplication1.Models;

namespace PoS.Repositories.PaymentRepository
{
    public interface IPaymentRepository
    {
        void Create(Payment payment);
    }
}
