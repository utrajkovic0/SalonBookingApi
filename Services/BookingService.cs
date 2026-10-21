using SalonBookingApi.Models;

namespace SalonBookingApi.Services
{
    public class BookingService
    {
        private List<Service> services = new()
        {
            new Service { Id = 1, Name = "Sisanje", DurationMinutes = 30, Price = 1200 },
            new Service { Id = 2, Name = "Brijanje", DurationMinutes = 30, Price = 800 }
        };

        private List<Appointment> appointments = new();

        public List<Service> GetServices()
        {
            return services;
        }

        public Service GetServiceById(int id)
        {
            return services.FirstOrDefault(s => s.Id == id);
        }

        public Service CreateService(Service newService)
        {
            newService.Id = services.Count == 0 ? 1 : services.Max(s => s.Id) + 1;
            services.Add(newService);
            return newService;
        }

        public bool UpdateService(int id, Service updatedService)
        {
            Service service = services.FirstOrDefault(s => s.Id == id);
            if (service == null) return false;

            service.Name = updatedService.Name;
            service.DurationMinutes = updatedService.DurationMinutes;
            service.Price = updatedService.Price;
            return true;
        }

        public bool DeleteService(int id)
        {
            Service service = services.FirstOrDefault(s => s.Id == id);
            if (service == null) return false;

            services.Remove(service);
            return true;
        }

        public List<Appointment> GetAppointments()
        {
            return appointments;
        }
        public Appointment GetAppointmentById(int id)
        {
            return appointments.FirstOrDefault(a => a.Id == id);
        }

        public Appointment BookAppointment(string clientName, int serviceId, DateTime dateTime)
        {
            Service service = GetServiceById(serviceId);

            if (service == null)
            {
                return null;
            }
            if (dateTime < DateTime.Now)
            {
                return null;
            }
            if (appointments.Any(a => a.DateTime == dateTime))
            {
                return null;
            }
            Appointment appointment = new()
            {
                Id = appointments.Count == 0 ? 1 : appointments.Max(a => a.Id) + 1,   
                ClientName = clientName,
                ServiceId = serviceId,
                DateTime = dateTime,
                Service = service
            };

            appointments.Add(appointment);
            
            return appointment;
        }
    }
}