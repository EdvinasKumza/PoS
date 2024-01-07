using PoS.Data;
using WebApplication1.Models;

namespace PoS.Repositories.TimeSlotRepository
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TimeSlotRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TimeSlot> GetTimeSlotsForService(string serviceId)
        {
            return _dbContext.TimeSlots
                .Where(ts => ts.ServiceId == serviceId)
                .ToList();
        }

        public List<TimeSlot> GetTimeSlotsForWorkers(string workerId)
        {
            return _dbContext.TimeSlots
                .Where(ts => ts.WorkerId == workerId)
                .ToList();
        }
        public TimeSlot GetTimeSlotById(string timeSlotId)
        {
            return _dbContext.TimeSlots.FirstOrDefault(ts => ts.TimeSlotId == timeSlotId);
        }
    }
}
