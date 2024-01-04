using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.SupplierService
{
    
    public class SupplierService : GenericService<Supplier>, ISupplierService
    {
        public SupplierService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
        // Implement any additional Supplier-specific methods, if needed
    }
}

