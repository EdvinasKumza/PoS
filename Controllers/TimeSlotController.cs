using Microsoft.AspNetCore.Mvc;
using PoS.Dtos.Order;
using PoS.Services.GenericServices;
using PoS.Services.TimeSlotServices;
using PoS.Services.OrderServices;
using PoS.Repositories.TimeSlotBookingRepository;
using WebApplication1.Models;

namespace PoS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeSlotController : ControllerBase
    {
        private readonly ITimeSlotService _timeSlotService;
        private readonly IGenericService<TimeSlot> _timeSlotGenericService;
        private readonly ITimeSlotBookingRepository _timeSlotBookingRepository;
        private readonly IOrderService _orderService;

        public TimeSlotController(ITimeSlotService timeSlotService
            , IGenericService<TimeSlot> timeSlotGenericService
            , ITimeSlotBookingRepository timeSlotBookingRepository
            , IOrderService orderService)
        {
            _timeSlotService = timeSlotService;
            _timeSlotGenericService = timeSlotGenericService;
            _timeSlotBookingRepository = timeSlotBookingRepository;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var timeslots = _timeSlotGenericService.GetAll();
            return Ok(timeslots);
        }
        [HttpPost]
        public IActionResult Post(TimeSlot timeslot)
        {
            _timeSlotGenericService.Create(timeslot);
            return CreatedAtAction(nameof(Get), new { id = timeslot.TimeSlotId }, timeslot);
        }

        [HttpGet("available-time-slots-service/{serviceId}")]
        public IActionResult GetTimeSlotsForService(string serviceId)
        {
            try
            {
                var timeSlots = _timeSlotService.GetTimeSlotsForService(serviceId);
                return Ok(timeSlots);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("available-time-slots-worker/{workerId}")]
        public IActionResult GetAvailableTimeSlotsForWorker(string workerId)
        {
            try
            {
                var availableTimeSlots = _timeSlotService.GetTimeSlotsForWorkers(workerId);

                return Ok(availableTimeSlots);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("book-time-slot")]
        public IActionResult BookTimeSlot(TimeSlotBooking bookingRequest)
        {
            try
            {
                // Validate the request
                if (bookingRequest == null || string.IsNullOrEmpty(bookingRequest.CustomerId) || string.IsNullOrEmpty(bookingRequest.TimeSlotId))
                {
                    return BadRequest("Invalid request. CustomerId and TimeSlotId are required.");
                }

                // Check if the time slot is available for booking
                var isAvailable = _timeSlotService.IsTimeSlotAvailableForBooking(bookingRequest.TimeSlotId);
                if (!isAvailable)
                {
                    return BadRequest("The selected time slot is not available for booking.");
                }

                // Create the booking
                _timeSlotService.BookTimeSlot(bookingRequest.CustomerId, bookingRequest.TimeSlotId);

                return Ok("Booking created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("cancel-booking/{bookingId}")]
        public IActionResult CancelBooking(string bookingId)
        {
            try
            {
                if (string.IsNullOrEmpty(bookingId))
                {
                    return BadRequest("Invalid request. BookingId is required.");
                }

                _timeSlotService.CancelBooking(bookingId);

                return Ok("Booking canceled successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("convert-booking-to-order/{bookingId}")]
        public IActionResult ConvertBookingToOrder(string bookingId, [FromBody] CreateOrderDto createOrderDto)
        {
            try
            {
                var booking = _timeSlotBookingRepository.GetBookingById(bookingId);

                if (booking == null)
                {
                    return NotFound("Booking not found.");
                }

                if (booking.Status == "Completed")
                {
                    return BadRequest("Can't convert bookings with Completed status into orders.");
                }

                var order = new CreateOrderDto
                {
                    CustomerId = booking.CustomerId,
                    TenantId = createOrderDto.TenantId,
                    PlacedBy = createOrderDto.PlacedBy,
                    Date = DateTime.Now,
                    TotalAmount = createOrderDto.TotalAmount,
                    DiscountApplied = createOrderDto.DiscountApplied,
                    Status = createOrderDto.Status,
                    Tips = createOrderDto.Tips,
                    TotalFee = createOrderDto.TotalFee,
                    Items = createOrderDto.Items
                };

                var createdOrder = _orderService.CreateFromBooking(order);

                _timeSlotBookingRepository.UpdateBookingStatus(bookingId, "Completed");

                return CreatedAtAction(nameof(Get), new { id = createdOrder.OrderId }, createdOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
