using System.ComponentModel.DataAnnotations;

namespace SalonBookingApi.DTOs
{
    public class CreateServiceDto
    {
        [Required]
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int DurationMinutes { get; set; }

        [Range (0, int.MaxValue)]
        public double Price {  get; set; }

    }
}
