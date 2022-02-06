using IMDbApiLib;
using IMDbApiLib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyProjectM.Data;
using MyProjectM.Models;
using System.Linq;

namespace MyProjectM.Controllers
{
    public class BookingController : Controller
    {
        private readonly AuthContext _context;

        public BookingController(AuthContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string id)
        {
            var apiLib = new ApiLib("k_3mj6zgvx");
            var data = await apiLib.TitleAsync(id, Language.en, "FullActor,FullCast,Posters,Images,Trailer,Ratings,Wikipedia");

            ViewBag.data = data;
            ViewBag.members = _context.Member.ToList();
            ViewBag.theaters = _context.theater.ToList();
            return View("~/Views/Home/Booking.cshtml");
        }
        public ActionResult Add(Order order)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Order.Add(order);
            //    _context.SaveChanges();
                
            //}
            return View();

        }

    }
}
