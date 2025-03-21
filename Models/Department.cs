using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMISWebApp.Models
{
    [Table("Department")]
    public class Department
    {
        [Column("DeptId")]
        public int Id { get; set; }

        [Display(Name = "Department Code")]
        public string? DeptCode { get; set; }

        [Display(Name = "Department Name")]
        public string? DeptName { get; set; }
    }

}
