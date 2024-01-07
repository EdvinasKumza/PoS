using PoS.Data;
using WebApplication1.Models;

namespace PoS.Repositories.LoyaltyProgramRepository
{
    public class LoyaltyProgramRepository : ILoyaltyProgramRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LoyaltyProgramRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public LoyaltyProgram GetById(string loyaltyProgramId)
        {
            return _dbContext.LoyaltyPrograms.FirstOrDefault(l => l.LoyaltyProgramId == loyaltyProgramId);
        }

        public IEnumerable<LoyaltyProgram> GetAll()
        {
            return _dbContext.LoyaltyPrograms.ToList();
        }

        public void Create(LoyaltyProgram loyaltyProgram)
        {
            _dbContext.LoyaltyPrograms.Add(loyaltyProgram);
            _dbContext.SaveChanges();
        }

        public void Update(LoyaltyProgram loyaltyProgram)
        {
            var existingLoyaltyProgram = _dbContext.LoyaltyPrograms.Find(loyaltyProgram.LoyaltyProgramId);

            if (existingLoyaltyProgram != null)
            {
                _dbContext.Entry(existingLoyaltyProgram).CurrentValues.SetValues(loyaltyProgram);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Loyalty program not found.");
            }
        }

        public void Delete(string loyaltyProgramId)
        {
            var loyaltyProgram = _dbContext.LoyaltyPrograms.Find(loyaltyProgramId);

            if (loyaltyProgram != null)
            {
                _dbContext.LoyaltyPrograms.Remove(loyaltyProgram);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Loyalty program not found.");
            }
        }
    }
}
