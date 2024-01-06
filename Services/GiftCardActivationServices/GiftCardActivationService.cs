using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.GiftCardActivationServices;

public class GiftCardActivationService : GenericService<GiftCardActivation>, IGiftCardActivationService
{
    public GiftCardActivationService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}