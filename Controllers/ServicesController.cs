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
        public async Task<ActionResult<List<Service>>> GetServices()
        {
            return Ok(await _bookingService.GetServicesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetServiceById(int id)
        {
            Service service = await _bookingService.GetServiceByIdAsync(id);
            
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<Service>> CreateService(Service newService)
        {
            await _bookingService.CreateServiceAsync(newService);

            return CreatedAtAction(nameof(GetServiceById), new { id = newService.Id }, newService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(int id, Service updatedService)
        {
            bool result = await _bookingService.UpdateServiceAsync(id, updatedService);
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();

         }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService (int id)
        {
            bool result =await _bookingService.DeleteServiceAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
