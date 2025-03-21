using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EMISWebApp.Models
{
    public class EmployeeDetailVM
    {
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Hired Date")]
        public DateTime? HiredDate { get; set; }
        [Display(Name = "Address")]
        public string? Address { get; set; }
        [Display(Name = "National Identification number")]
        public string? NationalIdentificationNo { get; set; }
        [Display(Name = "Department")]
        public int? DeptId { get; set; }
        [Display(Name = "Region")]
        public int? RegionId { get; set; }
        [Display(Name = "District")]
        public int? DistrictId { get; set; }
        [Display(Name = "Station")]
        public int? StationId { get; set; }
        [Display(Name = "Bank")]
        public int? BankId { get; set; }
        [Display(Name = "Account Number")]
        public string? AccountNumber { get; set; }
        [Display(Name = "Account Name")]
        public string? AccountName { get; set; }

        [Required]
        [Display(Name = "Employee Number")]
        public string? EmployeeNumber { get; set; }

        public string?  BankName { get; set; }
        public string? DeptName { get; set; }
        public string? StationName { get; set; }
        public string? DistrictName { get; set; }
        public string? RegionName { get; set; }

        public IEnumerable<SelectListItem> Regions { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
        public IEnumerable<SelectListItem> Stations { get; set; }
        public IEnumerable<SelectListItem> Banks { get; set; }
    }
}
