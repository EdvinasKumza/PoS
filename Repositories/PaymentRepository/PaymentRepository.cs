using PoS.Data;
using WebApplication1.Models;

namespace PoS.Repositories.PaymentRepository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public void Create(Payment payment)
        {
            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();
        }
    }
}
