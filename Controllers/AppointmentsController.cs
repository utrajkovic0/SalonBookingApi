using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonBookingApi.Models;

namespace SalonBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private static List<Appointment> appointments = new();


        [HttpGet]
        public List<Appointment> GetAppointments()
        {
            return appointments;
        }
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointmentById(int id)
        {
            Appointment appointment = appointments.FirstOrDefault(x => x.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }
    }
}
