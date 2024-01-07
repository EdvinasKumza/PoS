using System;
using System.Collections.Generic;
using System.Linq;
using PoS.Data;
using Microsoft.EntityFrameworkCore;
using PoS.Data;
using PoS.Services.GenericServices;
using WebApplication1.Models;
using PoS.Repositories.TimeSlotRepository;
using PoS.Repositories.TimeSlotBookingRepository;


namespace PoS.Services.TimeSlotServices
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly ITimeSlotBookingRepository _timeSlotBookingRepository;

        public TimeSlotService(ITimeSlotRepository timeSlotRepository, ITimeSlotBookingRepository timeSlotBookingRepository)
        {
            _timeSlotRepository = timeSlotRepository;
            _timeSlotBookingRepository = timeSlotBookingRepository;
        }

        public List<TimeSlot> GetTimeSlotsForService(string serviceId)
        {
            return _timeSlotRepository.GetTimeSlotsForService(serviceId);
        }
        public List<TimeSlot> GetTimeSlotsForWorkers(string workerId)
        {
            return _timeSlotRepository.GetTimeSlotsForWorkers(workerId);
        }
        public bool IsTimeSlotAvailableForBooking(string timeSlotId)
        {
            // Check if the time slot exists
            var timeSlot = _timeSlotRepository.GetTimeSlotById(timeSlotId);
            if (timeSlot == null)
            {
                throw new InvalidOperationException("Invalid time slot ID.");
            }

            // Check if the time slot is not already booked
            return !_timeSlotBookingRepository.HasBookingForTimeSlot(timeSlotId);
        }

        public void BookTimeSlot(string timeSlotId, string customerId)
        {
            // Check if the time slot is available for booking
            if (!IsTimeSlotAvailableForBooking(timeSlotId))
            {
                throw new InvalidOperationException("The selected time slot is not available for booking.");
            }

            // Create the booking
            var booking = new TimeSlotBooking
            {
                TimeSlotId = timeSlotId,
                CustomerId = customerId,
                BookingTime = DateTime.UtcNow, // Set the booking time to the current time
                                               // Add other properties for the booking
            };

            _timeSlotBookingRepository.Create(booking);
        }
        public void CancelBooking(string bookingId)
        {
            // Check if the booking exists
            var booking = _timeSlotBookingRepository.GetBookingById(bookingId);
            if (booking == null)
            {
                throw new InvalidOperationException("Invalid booking ID.");
            }

            // Cancel the booking (delete by ID)
            _timeSlotBookingRepository.CancelBooking(bookingId);
        }
    }
}
