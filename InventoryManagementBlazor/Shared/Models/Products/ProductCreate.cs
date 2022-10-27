using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementBlazor.Shared.Models.Products
{
    public class ProductCreate
    {
        
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public int StockNumber { get; set; }
        [Required]
        public string ProductLocation { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        public DateTimeOffset DateReceived { get; set; }
        
    }
}
