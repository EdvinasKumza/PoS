using WebApplication1.Models;

namespace PoS.Repositories.TimeSlotRepository
{
    public interface ITimeSlotRepository
    {
        List<TimeSlot> GetTimeSlotsForService(string serviceId);
        List<TimeSlot> GetTimeSlotsForWorkers(string workerId);
        TimeSlot GetTimeSlotById(string timeSlotId);
    }
}
