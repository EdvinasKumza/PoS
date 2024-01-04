using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.CustomerService;

public interface ICustomerService : IGenericService<Customer>
{        
    // Additional Customer-specific methods, if needed
}