namespace WebApplication4.Models
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AppDbContext _context;

        public HotelRepository(AppDbContext context)
        {
            _context = context; 
        }

        public Hotel Booking(int id)
        {
           Hotel? hotel = _context.DB_Hotel.FirstOrDefault(x => x.Id == id);
            if (hotel.Booking == true)
                hotel.Booking = false;
            else
                hotel.Booking = true;
            _context.SaveChanges();
            return hotel;
        }
        public Hotel Create(Hotel hotel)
        {
            _context.DB_Hotel.Add(hotel);
            _context.SaveChanges();
            return hotel;
        }

        public Hotel Delete(int id)
        {
           Hotel? hotel = _context.DB_Hotel.FirstOrDefault(x => x.Id == id);
            _context.DB_Hotel.Remove(hotel);
            _context.SaveChanges();
            return hotel;
        }

        public Hotel Get(int id)
        {
            Hotel? hotel = _context.DB_Hotel.FirstOrDefault(x => x.Id == id);
            return hotel;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _context.DB_Hotel.ToList();
        }

        public IEnumerable<Hotel> Search(string str)
        {
            IEnumerable<Hotel> hotels  = _context.DB_Hotel.Where(x => x.Name.Contains(str));

            return hotels;

        }
    }
}
