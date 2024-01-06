using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.CustomerServices;

public interface ICustomerService : IGenericService<Customer>
{        
    // Additional Customer-specific methods, if needed
}