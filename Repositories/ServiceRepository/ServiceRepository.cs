using PoS.Data;
using WebApplication1.Models;

namespace PoS.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ServiceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Service GetById(string serviceId)
        {
            return _dbContext.Services.FirstOrDefault(p => p.ServiceId == serviceId);
        }
    }
}
