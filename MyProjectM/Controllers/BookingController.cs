using Microsoft.AspNetCore.Mvc;

namespace MyProjectM.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Home/Booking.cshtml");
        }
    }
}
