using PoS.Data;
using PoS.Services.GenericServices;

namespace PoS.Services.LoyaltyProgramServices;

public class LoyaltyProgram : GenericService<LoyaltyProgram>, ILoyaltyProgramService
{
    public LoyaltyProgram(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}