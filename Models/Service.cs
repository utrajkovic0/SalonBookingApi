using System.ComponentModel.DataAnnotations;

namespace SalonBookingApi.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set;}

        [Range(1, int.MaxValue)]
        public int DurationMinutes { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
    }
}
