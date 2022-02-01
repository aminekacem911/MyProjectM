using Microsoft.AspNetCore.Mvc;

namespace MyProjectM.Controllers
{
    public class AdminController : Controller
    {
        //private readonly UserManager<ApplicationUser> userManager;
        //[Authorize]
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult UserList()
        //{
           
        //    return View(_context.Users.ToList());
        //}
    }
}
