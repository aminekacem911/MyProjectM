using IMDbApiLib;
using IMDbApiLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyProjectM.Data;
using MyProjectM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;

using System.Text.Json;
namespace MyProjectM.Controllers
{
    public class HomeController : Controller

    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthContext _context;

       

        public HomeController( AuthContext context)
        {
           
            _context = context;
        }
        
        public async Task<IActionResult> IndexAsync()
        {
            //k_3mj6zgvx
            var apiLib = new ApiLib("k_9yyzypa4"); 
            var data = await apiLib.Top250MoviesAsync();
            ViewBag.data = data;
            var coming = await apiLib.ComingSoonAsync();
            ViewBag.coming = coming;
            var boxes = await apiLib.BoxOfficeAsync();
            ViewBag.boxes = boxes;
            var ths = await apiLib.InTheatersAsync();
            ViewBag.ths = ths;
 
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
               _context.Contact.Add(contact);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        public IActionResult Faq()
        {
            return View();
        }
        public async Task<IActionResult> DetailsAsync(string id)
        {
            var apiLib = new ApiLib("k_3mj6zgvx");
            var data = await apiLib.TitleAsync(id, Language.en, "FullActor,FullCast,Posters,Images,Trailer,Ratings,Wikipedia");
           
            ViewBag.data = data;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
