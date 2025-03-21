using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EMISWebApp.Models
{
    public class EmployeeAllowanceVM
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Allowance Type")]
        public int? AllowanceId { get; set; }
        public IEnumerable<SelectListItem> Allowances{ get; set; }
    }
}
