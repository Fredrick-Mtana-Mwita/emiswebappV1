using EMISWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EMISWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            ViewBag.DateTime= DateTime.Now;
            ViewBag.Titlez = "Road Fund MVC Class";
            return View();
          
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public ContentResult GetContentResult()
        {
            string response = "Succes";
            return Content(response);
        }


        public JsonResult GetJsonResult ()
        {
            string response = "Succes";
            return Json(response);
        }


        public PartialViewResult GetPartialViewResult()
        {
           
            return PartialView("_Aside");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
