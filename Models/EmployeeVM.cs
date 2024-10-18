using System.ComponentModel.DataAnnotations;

namespace EMISWebApp.Models
{
    public class EmployeeVM
    {
        public string? EmployeeNumber { get; set; }
        public int EmployeeId { get; set; }
        public string?  EmployeeName { get; set; }
        public DateTime? BirthDate { get; set; }
        
        public DateTime? HiredDate { get; set; }
        public string? Address { get; set; }
        public string? NationalIdentificationNo { get; set; }
        public string? Region { get; set; }
        public string? District { get; set; }
        public string? Station { get; set; }
        public string? Department { get; set; }
        public string? Bank { get; set; }
    }
}
