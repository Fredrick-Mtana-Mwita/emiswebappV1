using EMISWebApp.DAL;
using EMISWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMISWebApp.Controllers
{
    public class StationController : Controller
    {
        private readonly EMISDBContext _context;

        public StationController(EMISDBContext context)
        {
            _context = context;
        }
        public IActionResult StationList()
        {
            var station = _context.Stations.OrderByDescending(x => x).ToList();
            return View(station);
        }

        [HttpGet]
        public IActionResult CreateStation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStation([Bind("StationName,StationCode")] Station station)
        {
            if (ModelState.IsValid)
            {
                _context.Stations.Add(station);
                _context.SaveChanges();
                return RedirectToAction("StationList");
            }
            return View(station);
        }
        [HttpGet]
        public ActionResult EditStation(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            Station? station = _context.Stations.Find(Id);
            if (station == null)
            {
                return NotFound();
            }
            return View(station);
        }
        [HttpPost]
        public IActionResult EditStation([Bind("StationName,StationCode,Id")] Station station)
        {

            if (ModelState.IsValid)
            {
                _context.Entry(station).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("StationList");
            }
            return View();

        }


        public JsonResult DeleteStation(int? id, string status)
        {

            string response = string.Empty;

            try
            {
                var station = _context.Stations.Find(id);
                _context.Stations.Remove(station);
                _context.SaveChanges();
                response = "Success";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return Json(response);
        }
    }
}







