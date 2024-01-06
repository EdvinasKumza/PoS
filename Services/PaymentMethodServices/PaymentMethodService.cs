using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.PaymentMethodServices;

public class PaymentMethodService : GenericService<PaymentMethod>, IPaymentMethodService
{
    public PaymentMethodService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}