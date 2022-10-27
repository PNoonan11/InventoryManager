using InventoryManagementBlazor.Shared.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementBlazor.Shared.Models.Customers
{
    public class CustomerDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<ProductListItem> ItemsPurchased { get; set; }
    }
}
}
