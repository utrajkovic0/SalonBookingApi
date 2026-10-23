using Microsoft.EntityFrameworkCore;
using SalonBookingApi.Models;

namespace SalonBookingApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
