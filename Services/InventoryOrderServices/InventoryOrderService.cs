using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.InventoryOrderServices;

public class InventoryOrderService : GenericService<InventoryOrder>, IInventoryOrderService
{
    public InventoryOrderService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}