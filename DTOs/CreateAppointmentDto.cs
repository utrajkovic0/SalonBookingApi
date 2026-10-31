using System.ComponentModel.DataAnnotations;

namespace SalonBookingApi.DTOs
{
    public class CreateAppointmentDto
    {
        [Required]
        public string ClientName { get; set; }

        [Range(1, int.MaxValue)]
        public int ServiceId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
