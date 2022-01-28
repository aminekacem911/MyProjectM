using IMDbApiLib;
using IMDbApiLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
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
        public IEnumerable<Movie> Movies { get; set; }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public async Task<IActionResult> IndexAsync()
        {
            var apiLib = new ApiLib("k_3mj6zgvx");
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
            
  
        public IActionResult Contact()
        {
            return View();
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
