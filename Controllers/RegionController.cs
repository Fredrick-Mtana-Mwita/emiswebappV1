using EMISWebApp.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EMISWebApp.Controllers
{
    public class RegionController : Controller
    {
        private readonly EMISDBContext _context;
        public RegionController(EMISDBContext context)
        {
            _context = context;
        }

        public IActionResult RegionList()
        {
            var regions = _context.Regions.ToList();
            return View(regions);
        }
    }
}
