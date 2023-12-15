using System;
using System.Collections.Generic;
using System.Linq;
using global::PoS.Data;
using Microsoft.EntityFrameworkCore;
using PoS.Data;
using WebApplication1.Models;

namespace PoS.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly ApplicationDbContext _dbContext;

        public WorkerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            return _dbContext.Workers.ToList();
        }

        public Worker GetWorkerById(string workerId)
        {
            return _dbContext.Workers.FirstOrDefault(worker => worker.WorkerId == workerId);
        }

        public void CreateWorker(Worker worker)
        {
            _dbContext.Workers.Add(worker);
            _dbContext.SaveChanges();
        }

        public void UpdateWorker(Worker worker)
        {
            _dbContext.Entry(worker).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteWorker(string workerId)
        {
            var worker = _dbContext.Workers.Find(workerId);
            if (worker != null)
            {
                _dbContext.Workers.Remove(worker);
                _dbContext.SaveChanges();
            }
        }
    }
}
