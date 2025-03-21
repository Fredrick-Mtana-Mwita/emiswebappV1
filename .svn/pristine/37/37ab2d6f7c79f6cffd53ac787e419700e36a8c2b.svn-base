using EMISWebApp.DAL;
using EMISWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EMISWebApp.Controllers
{
    public class EmployeeDetailController : Controller
    {
        private readonly EMISDBContext _context;

        public EmployeeDetailController(EMISDBContext context)
        {
            _context = context;
        }

        public IActionResult EmployeeList()
        {
            /*implementing LINQ*/
            var employee = (from a in _context.EmployeeDetails
                            join b in _context.Regions on a.RegionId equals b.RegionId
                            join c in _context.Districts on a.DistrictId equals c.DistrictId
                            join d in _context.Banks on a.BankId equals d.Id
                            join e in _context.Stations on a.StationId equals e.Id
                            join f in _context.Departments on a.DepartmentId equals f.Id
                            where b.RegionId == c.RegionId
                            select new EmployeeVM
                            {
                                EmployeeNumber = a.EmployeeNumber,
                                EmployeeId = a.EmployeeId,
                                EmployeeName = a.EmployeeName,
                                Bank = d.BankName,
                                Department = f.DeptName,
                                Station = e.StationName,
                                Region = b.RegionName,
                                District = c.DistrictName,
                                BirthDate = a.BirthDate,
                                HiredDate = a.HiredDate,
                                NationalIdentificationNo = a.NationalIdentificationNo,
                                Address = a.Address,
                            }).OrderByDescending(a => a.EmployeeId).ToList();
            return View(employee);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            EmployeeDetailVM employeeDetailVM = new EmployeeDetailVM();
            employeeDetailVM.Regions = new SelectList(_context.Regions.ToList(), "RegionId", "RegionName");
            employeeDetailVM.Departments = new SelectList(_context.Departments.ToList(), "Id", "DeptName");
            employeeDetailVM.Stations = new SelectList(_context.Stations.ToList(), "Id", "StationName");
            employeeDetailVM.Banks = new SelectList(_context.Banks.ToList(), "Id", "BankName");
            return View(employeeDetailVM);
        }

        public ActionResult GetDistrictList(int? regionId)
        {

            var district = _context.Districts.Where(a => a.RegionId == regionId).ToList();

            ViewBag.District = new SelectList(district, "DistrictId", "DistrictName");

            return PartialView("_DistrictList");

        }

        public JsonResult SaveEmployeeDetail(EmployeeDetailVM employeeDetailVM)
        {
            string response = string.Empty;
            try
            {
                var isEmployeeExists = _context.EmployeeDetails.Where(a => a.EmployeeNumber == employeeDetailVM.EmployeeNumber).Any();
                if (isEmployeeExists)
                {
                    response = "duplicate";

                    return Json(response);
                }
                var bankId = _context.Banks.Where(a => a.BankName == employeeDetailVM.BankName).Select(a => a.Id).FirstOrDefault();

                EmployeeDetail employeeDetail = new EmployeeDetail();
                employeeDetail.EmployeeNumber = employeeDetailVM.EmployeeNumber;
                employeeDetail.FirstName = employeeDetailVM.FirstName;
                employeeDetail.MiddleName = employeeDetailVM.MiddleName;
                employeeDetail.LastName = employeeDetailVM.LastName;
                employeeDetail.AccountNumber = employeeDetailVM.AccountNumber;
                employeeDetail.AccountName = employeeDetailVM.AccountName;
                employeeDetail.Address = employeeDetailVM.Address;
                employeeDetail.BirthDate = employeeDetailVM.BirthDate;
                employeeDetail.HiredDate = employeeDetailVM.HiredDate;
                employeeDetail.BankId = bankId;
                employeeDetail.StationId = employeeDetailVM.StationId;
                employeeDetail.DistrictId = employeeDetailVM.DistrictId;
                employeeDetail.RegionId = employeeDetailVM.RegionId;
                employeeDetail.DepartmentId = employeeDetailVM.DeptId;
                employeeDetail.NationalIdentificationNo = employeeDetailVM.NationalIdentificationNo;
                employeeDetail.StationId = employeeDetailVM.StationId;
                employeeDetail.CreatedBy = "Mwita Mtana";// Hard coded wait for user management
                employeeDetail.CreatedAt = DateTime.Now;
                employeeDetail.OverallStatus = "Pending";

                _context.EmployeeDetails.Add(employeeDetail);
                _context.SaveChanges();
                response = "success";
                return Json(response);
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }


            return Json(response);
        }


        public JsonResult RemoveEmployee(int? id, string status)
        {

            string response = string.Empty;

            try
            {
                var employee = _context.EmployeeDetails.Find(id);
                _context.EmployeeDetails.Remove(employee);
                _context.SaveChanges();
                response = "Success";
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return Json(response);
        }

        public ActionResult AddEmployeeAllowance(int id)
        {
            EmployeeAllowanceVM employeeAllowanceVM = new EmployeeAllowanceVM();
            var allowanceList = _context.Allowances.ToList();
            employeeAllowanceVM.EmployeeId = id;
            ViewBag.Allowances = new SelectList(allowanceList, "AllowanceId", "AllowanceName"); ;

            return PartialView("_AddEmployeeAllowance", employeeAllowanceVM);
        }

        public JsonResult SaveEmployeeAllowance(EmployeeAllowanceVM employeeAllowanceVM)
      {
            var response = "";
            try
            {
                var checkEmployeeAllowance = _context.EmployeeAllowances
                    .Where(a => a.EmployeeId == employeeAllowanceVM.EmployeeId
                    && a.AllowanceId == employeeAllowanceVM.AllowanceId).Any();

                if (checkEmployeeAllowance)
                {
                    response = "duplicate";
                    return Json(response);
                }

                if (employeeAllowanceVM.AllowanceId == null)
                {
                    response = "Error";
                    return Json(response);
                }

                EmployeeAllowance employeeAllowance = new EmployeeAllowance();
                employeeAllowance.AllowanceStatus = true;
                employeeAllowance.AllowanceId = employeeAllowanceVM.AllowanceId;
                employeeAllowance.EmployeeId = employeeAllowanceVM.EmployeeId;
                employeeAllowance.CreatedBy = "Mwita Mtana";
                employeeAllowance.CreatedAt = DateTime.Now;

                _context.EmployeeAllowances.Add(employeeAllowance);
                _context.SaveChanges();

                response = "success";
                return Json(response);
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return Json(response);
        }


        public IActionResult ViewDetail(int? id)
        {

            var employeeDetail = (from a in _context.EmployeeDetails
                                  join d in _context.Districts on a.DistrictId equals d.DistrictId
                                  join r in _context.Regions on a.RegionId equals r.RegionId
                                  where a.EmployeeId == id
                                  select new EmployeeDetailVM
                                  {
                                      FirstName = a.FirstName,
                                      LastName = a.LastName,
                                      MiddleName = a.MiddleName,
                                      Address = a.Address,
                                      NationalIdentificationNo = a.NationalIdentificationNo,
                                      AccountName = a.AccountName,
                                      AccountNumber = a.AccountNumber,
                                      BirthDate = a.BirthDate,
                                      HiredDate = a.HiredDate,
                                      DistrictName = d.DistrictName,
                                      RegionName = r.RegionName
                                  }).FirstOrDefault();

            var employeeAllowances = (from b in _context.EmployeeAllowances
                                      join c in _context.Allowances on b.AllowanceId equals c.AllowanceId
                                      where b.EmployeeId == id
                                      select new EmployeeAllowanceDetailVM
                                      {
                                          AllowanceCode = c.AllowanceCode,
                                          AllowanceName = c.AllowanceName,  
                                          AllowanceAmount = c.Amount,
                                          AllowanceStatus = b.AllowanceStatus == true ? "Active": "Inactive",//ternary operators(?-if),(:"else")
                                      } ).ToList();

            ViewBag.AllowanceList = employeeAllowances;
            return PartialView("_EmployeeAllowanceDetail", employeeDetail);
        }


        public IActionResult EditEmployeeDetailList(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            EmployeeDetail? employeeDetail = _context.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return View(employeeDetail);
        }

        [HttpPost]
        public IActionResult EditEmployeeDetailList([Bind("FirstName,MiddleName,EmployeeId,LastName,BirthDate,HiredDate,Address,NationalIdentificationNo,AccountNumber,AccountName,CreatedBy,CreatedAt,OverallStatus")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(employeeDetail).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("EmployeeList");
            }
            return View(employeeDetail);
        }

    }
}
