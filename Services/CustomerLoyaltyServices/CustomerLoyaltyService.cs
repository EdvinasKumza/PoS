using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.CustomerLoyaltyServices;

public class CustomerLoyaltyService : GenericService<CustomerLoyalty>, ICustomerLoyaltyService
{
    public CustomerLoyaltyService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}