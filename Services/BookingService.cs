using SalonBookingApi.Data;
using SalonBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SalonBookingApi.Services
{
    public class BookingService
    {
        private readonly AppDbContext _context;
        
        public BookingService (AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetServicesAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Service> CreateServiceAsync(Service newService)
        {
            _context.Services.Add(newService);
            await _context.SaveChangesAsync();
            return newService;
        }

        public async Task<bool> UpdateServiceAsync(int id, Service updatedService)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            if (service == null) return false;

            service.Name = updatedService.Name;
            service.DurationMinutes = updatedService.DurationMinutes;
            service.Price = updatedService.Price;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            if (service == null) return false;

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Appointment>> GetAppointmentAsync()
        {
            return await _context.Appointments.ToListAsync();
        }
        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Appointment> BookAppointmentAsync(string clientName, int serviceId, DateTime dateTime)
        {
            var service = await GetServiceByIdAsync(serviceId);

            if (service == null)
            {
                return null;
            }
            if (dateTime < DateTime.Now)
            {
                return null;
            }
            if (await _context.Appointments.AnyAsync(a => a.DateTime == dateTime))
            {
                return null;
            }
            Appointment appointment = new()
            {
                ClientName = clientName,
                ServiceId = serviceId,
                DateTime = dateTime,
                Service = service
            };

            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }
    }
}