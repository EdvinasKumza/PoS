using PoS.Data;
using WebApplication1.Models;

namespace PoS.Repositories.PaymentMethodRepository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentMethodRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PaymentMethod GetById(string paymentMethodId)
        {
            return _dbContext.PaymentMethods.FirstOrDefault(p => p.PaymentMethodId == paymentMethodId);
        }
    }
}
