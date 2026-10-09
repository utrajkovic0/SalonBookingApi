namespace SalonBookingApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int ServiceId { get; set; }
        public DateTime DateTime { get; set; }
        public Service Service { get; set; }
    }
}
