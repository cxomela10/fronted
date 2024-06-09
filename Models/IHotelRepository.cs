namespace WebApplication4.Models
{
    public interface IHotelRepository
    {
        Hotel Create(Hotel hotel);
        IEnumerable<Hotel> GetAll();
        Hotel Get(int id);
        Hotel Delete(int id);
        Hotel Booking(int id);
        IEnumerable<Hotel> Search(string str);

    }
}
