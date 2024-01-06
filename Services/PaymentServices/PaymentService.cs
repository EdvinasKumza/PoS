using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.PaymentServices;

public class PaymentService : GenericService<Payment>, IPaymentService
{
    public PaymentService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}