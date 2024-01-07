using WebApplication1.Models;

namespace PoS.Repositories.LoyaltyProgramRepository
{
    public interface ILoyaltyProgramRepository
    {
        LoyaltyProgram GetById(string loyaltyProgramId);
        IEnumerable<LoyaltyProgram> GetAll();
        void Create(LoyaltyProgram loyaltyProgram);
        void Update(LoyaltyProgram loyaltyProgram);
        void Delete(string loyaltyProgramId);
    }
}
