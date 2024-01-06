using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.GiftCardTranastionServices;

public class GiftCardTransactionService : GenericService<GiftCardTransaction>, IGiftCardTransactionService
{
    public GiftCardTransactionService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}