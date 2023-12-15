using WebApplication1.Models;

namespace PoS.Services
{
    public interface IWorkerService
    {
        IEnumerable<Worker> GetAllWorkers();
        Worker GetWorkerById(string workerId);
        void CreateWorker(Worker worker);
        void UpdateWorker(Worker worker);
        void DeleteWorker(string workerId);
    }
}
