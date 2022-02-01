using Microsoft.AspNetCore.Mvc;
using MyProjectM.Data;
using System.Linq;
using System.Collections.Generic;
using MyProjectM.Models;
using Microsoft.EntityFrameworkCore;

namespace MyProjectM.Controllers
{
    public class AdminController : Controller
    {
        private readonly AuthContext _context;



        public AdminController(AuthContext context)
        {

            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ContactListe()
        {

            return View(_context.Contact.ToList());
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Contact.Where(x => x.Id == id).FirstOrDefault();
            _context.Contact.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("ContactListe");
        }

    }
}
