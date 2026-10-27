using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonBookingApi.DTOs;
using SalonBookingApi.Models;
using SalonBookingApi.Services;

namespace SalonBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public AppointmentsController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> GetAppointments()
        {
            return Ok(await _bookingService.GetAppointmentAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointmentById(int id)
        {
            Appointment appointment = await _bookingService.GetAppointmentByIdAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> BookAppointment(CreateAppointmentDto request)
        {
            Appointment appointment = await _bookingService.BookAppointmentAsync(
                request.ClientName, request.ServiceId, request.DateTime);

            if (appointment == null)
            {
                return BadRequest("Nije moguce zakazati termin");
            }

            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, appointment);
        }
    }
}
 