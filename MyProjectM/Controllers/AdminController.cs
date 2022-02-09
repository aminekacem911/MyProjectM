using Microsoft.AspNetCore.Mvc;
using MyProjectM.Data;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using MyProjectM.Areas.Identity.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Identity.UI.Services;
using static Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal.LoginModel;

namespace MyProjectM.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        private readonly AuthContext _context;
        private readonly UserManager<MyProjectMUser> _userManager;
        private readonly SignInManager<MyProjectMUser> _signInManager;

        public AdminController(SignInManager<MyProjectMUser> signInManager, AuthContext context, UserManager<MyProjectMUser> userManager)
        {

            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [BindProperty]
        public InputModel Input { get; set; }
        public IActionResult Index()
        {
            
            ViewBag.users = _context.users.ToList().Count();
            ViewBag.orders = 0;// _context.orders.ToList().Count();
            ViewBag.requests = _context.Contact.ToList().Count(); ;
            return View();
        }
        public IActionResult Users()
        {
            return View(_context.users.ToList());
        }


        public async Task<IActionResult> ContactListeAsync()
        {
            var user = await _userManager.FindByEmailAsync("admin@admin.com");
            string returnUrl = null;
            returnUrl = returnUrl ?? Url.Content("~/");
            if (user.Isadmin == "1")
            {
                return View(_context.Contact.ToList());
            }
            else
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");


            }

            //redirect to panel admin
            // return View(_context.Contact.ToList());


            //return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");





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
