using WebApplication1.Models;

namespace PoS.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Service GetById(string serviceId);
    }
}
