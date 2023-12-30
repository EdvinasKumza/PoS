using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.WorkerServices
{
    /*
    public interface IWorkerService
    {
        IEnumerable<Worker> GetAllWorkers();
        Worker GetWorkerById(string workerId);
        void CreateWorker(Worker worker);
        void UpdateWorker(Worker worker);
        void DeleteWorker(string workerId);
    }
    */
    public interface IWorkerService : IGenericService<Worker>
    {
        // Additional Worker-specific methods, if needed
    }
}
