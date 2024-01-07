using System;
using WebApplication1.Models;
namespace PoS.Repositories.TimeSlotBookingRepository
{

    public interface ITimeSlotBookingRepository
    {
        bool HasBookingForTimeSlot(string timeSlotId);
        void Create(TimeSlotBooking booking);
        TimeSlotBooking GetBookingById(string bookingId);
        void CancelBooking(string bookingId);
    }
}
