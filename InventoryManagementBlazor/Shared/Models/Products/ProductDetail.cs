using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementBlazor.Shared.Models.Products
{
    public class ProductDetail
    {
        
        public int Id { get; set; }       
        public string ProductName { get; set; }       
        public string ProductDescription { get; set; }       
        public int StockNumber { get; set; }     
        public string ProductLocation { get; set; }       
        public int Quantity { get; set; }
        public DateTimeOffset DateReceived { get; set; }
        public DateTimeOffset? DateLastSold { get; set; }
    }
}
