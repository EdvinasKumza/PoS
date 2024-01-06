using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.GiftCardServices;

public class GiftCardService : GenericService<GiftCard>, IGiftCardService
{
    public GiftCardService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}