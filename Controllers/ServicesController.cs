using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonBookingApi.Models;
using SalonBookingApi.Services;

namespace SalonBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public ServicesController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public ActionResult<List<Service>> GetServices()
        {
            return Ok(_bookingService.GetServices());
        }

        [HttpGet("{id}")]
        public ActionResult<Service> GetServiceById(int id)
        {
            Service service = _bookingService.GetServiceById(id);
            
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        [HttpPost]
        public ActionResult<Service> CreateService(Service newService)
        {
            _bookingService.CreateService(newService);

            return CreatedAtAction(nameof(GetServiceById), new { id = newService.Id }, newService);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, Service updatedService)
        {
            bool result = _bookingService.UpdateService(id, updatedService);
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();

         }

        [HttpDelete("{id}")]
        public IActionResult DeleteService (int id)
        {
            bool result = _bookingService.DeleteService(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
