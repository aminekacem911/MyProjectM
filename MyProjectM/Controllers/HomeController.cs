using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProjectM.Data;
using MyProjectM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Index()
        {
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
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
