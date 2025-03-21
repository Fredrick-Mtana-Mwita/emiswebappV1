using EMISWebApp.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EMISWebApp.Controllers
{
    public class BankController : Controller
    {
        private readonly EMISDBContext _context;
        public BankController(EMISDBContext context)
        {
            _context = context;   
        }
        public IActionResult BankList()
        {
            return View(_context.Banks.ToList());
        }
    }
}
