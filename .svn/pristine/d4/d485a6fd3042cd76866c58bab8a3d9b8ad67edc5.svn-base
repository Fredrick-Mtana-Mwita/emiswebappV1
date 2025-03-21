using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMISWebApp.Models
{
    [Table("EmployeeDetail")]
    public class EmployeeDetail
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]  
        public string? EmployeeNumber { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HiredDate { get; set; }
        public string? Address { get; set; }
        public string? NationalIdentificationNo { get; set; }
        public int? DepartmentId { get; set; }
        public int? RegionId { get; set; }
        public int? DistrictId { get; set; }
        public int? StationId { get; set; }
        public int? BankId { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? OverallStatus { get; set; }

        public string EmployeeName 
        {
            get
            {
                return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
            }
        }
    }
}
