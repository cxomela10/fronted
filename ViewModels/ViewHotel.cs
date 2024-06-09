using WebApplication4.Models;

namespace WebApplication4.ViewModels
{
    public class ViewHotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public City City { get; set; }
        public IFormFile Photo { get; set; }
    }
}
