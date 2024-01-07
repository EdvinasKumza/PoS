using PoS.Data;
using WebApplication1.Models;

namespace PoS.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product GetById(string productId)
        {
            return _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
