
using PoS.Data;
using PoS.Repositories.CustomerRepository;
using WebApplication1.Models;

namespace PoS.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer GetById(string customerId)
        {
            // Using Include to load related data if necessary
            return _dbContext.Customers.FirstOrDefault(c => c.CustomerID == customerId);
        }
    }
}
