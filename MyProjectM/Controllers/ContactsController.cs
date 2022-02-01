using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using MyProjectM.Data;
using MyProjectM.Models;
using System;

namespace MyProjectM.Controllers
{
   
    public class ContactsController : Controller

    {
        private readonly AuthContext _context;

        public ContactsController(AuthContext context)
        {
            _context = context;
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ajouter(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contact.Add(contact);
                _context.SaveChanges();
                //:::://return RedirectToAction("Index");
            }
            return View(contact);

        }


        
}
}