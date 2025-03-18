using EMISWebApp.DAL;
using EMISWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Net;

namespace EMISWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly EMISDBContext _context;
        public DepartmentController(EMISDBContext context)
        {
            _context = context;
        }
        public IActionResult DepartmentList()
        {
            return View(_context.Departments.OrderByDescending(a => a.Id).ToList());
        }

        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDepartment([Bind("DeptCode,DeptName")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("DepartmentList");
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult EditDepartment(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Department? department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        public IActionResult EditDepartment([Bind("DeptCode,DeptName,Id")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(department).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("DepartmentList");
            }
            return View(department);
        }

        public JsonResult DeleteDepartment(int? id,string status)
        {

            string response = string.Empty;

            try
            {
                var department  = _context.Departments.Find(id);
                _context.Departments.Remove(department);
                _context.SaveChanges();
                response = "Success";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return Json(response);
        }
        public JsonResult RemoveDepartment(int? id, string status)
        {
            string response = string.Empty;

            try
            {
                var department = _context.Departments.Find(id);
                _context.Departments.Remove(department);
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

