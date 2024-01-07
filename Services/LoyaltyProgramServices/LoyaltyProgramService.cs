using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.LoyaltyProgramServices;

public class LoyaltyProgramService : GenericService<LoyaltyProgram>, ILoyaltyProgramService
{
    public LoyaltyProgramService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}