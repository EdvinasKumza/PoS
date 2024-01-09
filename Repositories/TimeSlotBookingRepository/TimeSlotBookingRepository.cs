using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PoS.Data;
using WebApplication1.Models;

namespace PoS.Repositories.TimeSlotBookingRepository
{
    public class TimeSlotBookingRepository : ITimeSlotBookingRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TimeSlotBookingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool HasBookingForTimeSlot(string timeSlotId)
        {
            return _dbContext.TimeSlotBookings.Any(booking => booking.TimeSlotId == timeSlotId);
        }

        public void Create(TimeSlotBooking booking)
        {
            if (booking.BookingTime == default)
            {
                booking.BookingTime = DateTime.UtcNow;
            }

            _dbContext.TimeSlotBookings.Add(booking);
            _dbContext.SaveChanges();
        }
        public TimeSlotBooking GetBookingById(string bookingId)
        {
            return _dbContext.TimeSlotBookings.FirstOrDefault(booking => booking.BookingId == bookingId);
        }
        public void CancelBooking(string bookingId)
        {
            var booking = GetBookingById(bookingId);

            if (booking != null)
            {
                _dbContext.TimeSlotBookings.Remove(booking);
                _dbContext.SaveChanges();
            }
        }
        public void UpdateBookingStatus(string bookingId, string newStatus)
        {
            var booking = _dbContext.TimeSlotBookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (booking != null)
            {
                booking.Status = newStatus;
                _dbContext.SaveChanges();
            }
        }
    }
}
