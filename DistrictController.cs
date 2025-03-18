using EMISWebApp.DAL;
using EMISWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMISWebApp.Controllers
{
    public class DistrictController : Controller
    {
        private readonly EMISDBContext _context;

        public DistrictController(EMISDBContext context)
        {
            _context = context;
        }
        public ActionResult DistrictList()
        {

            var Districts = _context.Districts.ToList();
            return View(Districts);
        }


        [HttpGet]
        public IActionResult CreateDistrict()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDistrict([Bind("DistrictName")] District district)
        {
            if (ModelState.IsValid)
            {
                _context.Districts.Add(district);
                _context.SaveChanges();
                return RedirectToAction("DistrictList");
            }
            return View(district);
        }
    }
}
