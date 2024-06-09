namespace WebApplication4.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public string Description { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Rating Rating { get; set; }
        public string PhotoUrl { get; set; }
        public bool Booking { get; set; }

    }
}
