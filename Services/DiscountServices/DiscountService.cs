using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.DiscountServices;

public class DiscountService : GenericService<Discount>, IDiscountService
{
    public DiscountService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}