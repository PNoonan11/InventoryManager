namespace InventoryManagementBlazor.Server.Models
{
    public class SaleEntity
    {
        public int Id { get; set; }
        public string ProductSold { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantitySold { get; set; }
        public int LocationSoldFrom { get; set; }
        public DateTimeOffset DateOfSale { get; set; }
        public int CustomerSoldTo { get; set; }
        public ICollection<CustomerEntity> Customer { get; set; }
        public int SoldByUserId { get; set; }
    }
}
