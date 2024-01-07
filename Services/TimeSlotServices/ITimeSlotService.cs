using PoS.Services.GenericServices;
using WebApplication1.Models;

namespace PoS.Services.TimeSlotServices
{
    public interface ITimeSlotService
    {

        List<TimeSlot> GetTimeSlotsForService(string serviceId);
        List<TimeSlot> GetTimeSlotsForWorkers(string workerId);
        bool IsTimeSlotAvailableForBooking(string timeSlotId);
        void BookTimeSlot(string timeSlotId, string customerId);
        void CancelBooking(string bookingId);
    }
}
