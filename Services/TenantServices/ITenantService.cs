using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.TenantServices
{
    public interface ITenantService : IGenericService<Tenant>
    {
        // Additional Tenant-specific methods, if needed
    }
}
