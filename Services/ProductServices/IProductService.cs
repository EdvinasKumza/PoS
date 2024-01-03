using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.ProductServices
{
    public interface IProductService : IGenericService<Product>
    {
        // Additional Product-specific methods, if needed
    }
}
