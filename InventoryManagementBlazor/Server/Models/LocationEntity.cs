using System.ComponentModel.DataAnnotations;

namespace InventoryManagementBlazor.Server.Models
{
    public class LocationEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
