namespace SalonBookingApi.DTOs
{
    public class CreateAppointmentDto
    {
        public string ClientName { get; set; }
        public int ServiceId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
