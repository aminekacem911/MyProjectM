using IMDbApiLib;
using IMDbApiLib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyProjectM.Data;
using MyProjectM.Models;
using System.Linq;
using System.Collections.Generic;
using System;

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(){
            string ticket = Request.Form["Numticket"].ToString();
            string film = Request.Form["Film"].ToString();
            string user = Request.Form["User"].ToString();
            string include = Request.Form["Include"].ToString(); //yes or no
            string theater = Request.Form["Theater"].ToString();
          // string listmember = Request.Form["Members"];
            string[] member = Request.Form["Members"];
            string combinedString = string.Join(",", member);

            Order or = new Order();
            or.Film = film;
            or.User = user;
            or.Numticket=ticket;
            or.Theater = theater;
            or.Members = combinedString;
            _context.Orders.Add(or);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //public async Task<IActionResult> Add(string film, string user,string numticket,string theater,string include, System.Collections.Generic.List<string> Members)
        //{

        //    Order or = new Order(); 
        //    or.Film = film;
        //    or.User = user;
        //    or.Numticket = numticket;
        //    or.Theater = theater;
        //    or.Include = include;
        //    or.Members = Members;
        //    //if (or.Include == "Yes")
        //    //{

        //    //}
        //    //else
        //    //{

        //    //}
        //    //if (ModelState.IsValid)
        //    //{
        //    _context.Add(or);
        //       await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //    //}
        //    //return View("Done");
        //}
        //public ActionResult Add(string member,string th)
        //{
        //    Order or = new Order();
        //    or.Members = member;
        //    or.Include = "Yee";
        //    or.Theater =
        //    //if (ModelState.IsValid)
        //    //{
        //    //    _context.Orders.Add(order);
        //    //    _context.SaveChanges();

        //    //}
        //    return RedirectToAction("Index");
        //}
        public IActionResult Done()
        {
            return View("~/Views/Home/Done.cshtml");
        }

    }
}
