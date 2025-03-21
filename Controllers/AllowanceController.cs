using EMISWebApp.DAL;
using EMISWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMISWebApp.Controllers
{
    public class AllowanceController : Controller
    {
        private readonly EMISDBContext _context;
       
        public AllowanceController(EMISDBContext context)
        {
            _context = context;
        }
        public IActionResult AllowanceList()
        {
            return View(_context.Allowances.ToList());
        }

        [HttpGet]
        public IActionResult CreateAllowance()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAllowance([Bind("AllowanceCode,AllowanceName,Amount")] Allowance allowance)
        {
            if (ModelState.IsValid)
            {
                _context.Allowances.Add(allowance);
                _context.SaveChanges();
                return RedirectToAction("AllowanceList");
            }
            return View(allowance);
        }
        [HttpGet]
        public IActionResult EditAllowance(int? id)
        {
            if (id == null)
            { 
                return BadRequest();
            }
            Allowance? allowance = _context.Allowances.Find(id);
            if (allowance == null)
            {

            return NotFound(); 
            }
            return View(allowance);
        }
        [HttpPost]
        public IActionResult EditAllowance([Bind("AllowanceCode,AllowanceName,Amount,Id")] Allowance allowance)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(allowance).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("AllowanceList");
            }
            return View(allowance);
        }
    }
}
