using Microsoft.AspNetCore.Mvc;

namespace MyProjectM.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
