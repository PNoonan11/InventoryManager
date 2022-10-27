using System.ComponentModel.DataAnnotations;

namespace InventoryManagementBlazor.Server.Models
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public int StockNumber { get; set; }
        [Required]
        public string ProductLocation { get; set; }
        public virtual LocationEntity Locations { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTimeOffset DateReceived { get; set; }
        public DateTimeOffset? DateLastSold { get; set; }
        
    }
}
