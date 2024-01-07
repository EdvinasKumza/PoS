using WebApplication1.Models;

namespace PoS.Repositories.CustomerRepository
{
    public interface ICustomerRepository
    {
        Customer GetById(string customerId);
    }
}