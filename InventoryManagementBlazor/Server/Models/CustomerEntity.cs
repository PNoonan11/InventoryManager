using InventoryManagementBlazor.Shared.Models.Products;

namespace InventoryManagementBlazor.Server.Models
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public ICollection<ProductListItem> ItemsPurchased { get; set; }
    }
}
