using IMDbApiLib;
using IMDbApiLib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyProjectM.Data;
using MyProjectM.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;

namespace MyProjectM.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly AuthContext _context;

        public BookingController(AuthContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string id)
        {
            var apiLib = new ApiLib("k_9yyzypa4");
            var data = await apiLib.TitleAsync(id, Language.en, "FullActor,FullCast,Posters,Images,Trailer,Ratings,Wikipedia");

            ViewBag.data = data;
            ViewBag.members = _context.Member.Where(m => m.User == User.Identity.GetUserName())
                                      .ToList();
            ViewBag.theaters = _context.theater.ToList();
            return View("~/Views/Home/Booking.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddAsync(){

            int total = int.Parse(Request.Form["Total"]);
            int ticket = int.Parse(Request.Form["Numticket"]);
            string film = Request.Form["Film"].ToString();
            string user = Request.Form["User"].ToString();
           // string include = Request.Form["Include"].ToString(); //yes or no
            int include = int.Parse(Request.Form["Include"]);
            int theater = int.Parse(Request.Form["Theater"].ToString());
            string[] getmembere = Request.Form["Members"];
            //from DB
            var gettheaterdata = await _context.theater
                .FirstOrDefaultAsync(m => m.TheaterID == theater);
            var getticketdata = await _context.Ticket.FirstAsync();
            //
            
            var membercount = 0;
            
            string combinedString = "";
             
            if (include == 1)
            {
                
                combinedString = string.Join( user + ",", getmembere);
                membercount = Request.Form["Members"].Count +1 ;

            }
            if (include == 0)
            {
                combinedString = string.Join(",", getmembere);
                membercount = Request.Form["Members"].Count;

            }
            Order or = new Order();
            or.Film = film;
            or.User = user;
            or.Numticket= ticket;
            or.Theater = gettheaterdata.Place;
            or.Members = combinedString;
            or.Include = include;
            or.Total = membercount * getticketdata.Price;
            if(gettheaterdata.Capacity > ticket)
            {  
                //if(ticket == membercount)
                //{
                    ///for theater
                    gettheaterdata.Capacity = gettheaterdata.Capacity - ticket;
                    _context.Update(gettheaterdata);
                    _context.SaveChanges();
                    //for order
                    _context.Orders.Add(or);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Done));
                    TempData["msg"] = "<script>alert('Done !!');</script>";
                    ViewBag.YMessage = "done !";
                //}
                //else
                //{
                //    TempData["msg"] = "<script>alert('Number Tickets and Number of members Not equals!);</script>";
                //    //ViewBag.NMessage = "Number Tickets and Number of members Not equals!";
                //    return RedirectToAction(nameof(Index));
                //}


            }
            else
            {
                TempData["msg"] = "<script>alert('capacity Theater reached ');</script>";
                //ViewBag.NMessage = "capacity Theater reached !";
                return RedirectToAction(nameof(Index));
            }
           
        }
       
        public IActionResult Done()
        {
            return View("~/Views/Home/Done.cshtml");
        }

    }
}
