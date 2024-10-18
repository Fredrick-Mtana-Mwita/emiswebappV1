using System.ComponentModel.DataAnnotations.Schema;

namespace EMISWebApp.Models
{
    [Table("Region")]
    
    public class Region
    {
        public int RegionId { get; set; }

        public string? RegionName { get; set; }
    }
}
