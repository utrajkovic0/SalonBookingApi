using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonBookingApi.Models;

namespace SalonBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private static List<Service> services = new()
        {
            new Service { Id = 1, Name = "Sisanje", DurationMinutes = 30, Price = 1200.00 },
            new Service { Id = 2, Name = "Brijanje", DurationMinutes = 30, Price = 800.00 }
        };

        [HttpGet]
        public List<Service> GetServices()
        {
            return services;
        }
        [HttpGet("{id}")]
        public ActionResult<Service> GetServiceById(int id)
        {
            Service service = services.FirstOrDefault(s => s.Id == id);

            if (service == null)
            {
                return NotFound(); 
            }

            return Ok(service);  
        }

        [HttpPost]
        public ActionResult<Service> CreateService(Service newService)
        {
            newService.Id = services.Max(s => s.Id) + 1;
            
            services.Add(newService);

            return CreatedAtAction(nameof(GetServiceById), new { id = newService.Id }, newService);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, Service updatedService)
        {
            Service service = services.FirstOrDefault(s => s.Id == id);

            if (service == null)
            {
                return NotFound();
            }

            service.Name = updatedService.Name;
            service.DurationMinutes = updatedService.DurationMinutes;
            service.Price = updatedService.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService (int id)
        {
            Service deletedService = services.FirstOrDefault(s => s.Id == id);

            if (deletedService == null)
            {
                return NotFound();
            }

            services.Remove(deletedService);

            return NoContent();
        }
    }
}
