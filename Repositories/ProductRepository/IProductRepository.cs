using WebApplication1.Models;

namespace PoS.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Product GetById(string productId);
    }
}
