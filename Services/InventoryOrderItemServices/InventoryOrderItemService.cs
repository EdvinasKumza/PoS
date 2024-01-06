using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.InventoryOrderItemServices;

public class InventoryOrderItemService : GenericService<InventoryOrderItem>, IInventoryOrderItemService
{
    public InventoryOrderItemService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}