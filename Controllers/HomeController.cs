using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication4.Models;
using WebApplication4.ViewModels;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHotelRepository _hotelRepositoy;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IHotelRepository hotelRepository , IWebHostEnvironment webHostEnvironment)
        {
            _hotelRepositoy = hotelRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Hotel> hotels = _hotelRepositoy.GetAll();
            return View(hotels);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
             Hotel viewDelete = _hotelRepositoy.Delete(id);
             return RedirectToAction("Index",viewDelete);
        }
        [HttpGet]
        public IActionResult Booking(int id)
        {
            Hotel viewBooking = _hotelRepositoy.Booking(id);
            return RedirectToAction("Details", viewBooking);
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            ViewDetails viewDetails = new ViewDetails()
            {
                hotel = _hotelRepositoy.Get(id),
                PageTitle = "Employee Details"
            };

            return View(viewDetails);
        }

        public IActionResult Search(string str)
        {
            ViewBag.str = str;
            var hotels = _hotelRepositoy.Search(str);
            return View(hotels);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ViewHotel hotel)
        {
            string? RandonFileName = null;
            string? Folder = null;
            string? FileUrl = null;
            Folder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
            RandonFileName = Guid.NewGuid().ToString() + "_" + hotel.Photo.FileName;
            FileUrl = Path.Combine(Folder, RandonFileName);
            hotel.Photo.CopyTo(new FileStream(FileUrl, FileMode.Create));

            Hotel newhotel = new Hotel()
            {
                Name = hotel.Name,
                Address = hotel.Address,
                City = hotel.City,
                PhoneNumber = hotel.PhoneNumber,
                Mail = hotel.Mail,
                Description = hotel.Description,
                PhotoUrl = RandonFileName

            };
            _hotelRepositoy.Create(newhotel);
            return RedirectToAction("Index" , new {id = newhotel.Id});

        }

        





    }
}