using InventoryManagementBlazor.Server.Data;
using InventoryManagementBlazor.Server.Models;
using InventoryManagementBlazor.Shared.Models.Sales;

namespace InventoryManagementBlazor.Server.Services.Sales
{
    public class SaleServices : ISaleServices
    {
        private readonly ApplicationDbContext _context;
        public SaleServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateSaleAsync(SaleCreate model)
        {
            var newSaleEntry = new SaleEntity
            {
                ProductSold = model.ProductSold,
                ProductId = model.ProductId,
                ProductQuantitySold = model.ProductQuantitySold,
                LocationSoldFrom = model.LocationSoldFrom,

            }
        }
        public async Task<IEnumerable<SaleListItem>> GetAllSalesAsync()
        {

        }
        public async Task<SaleDetail> GetSaleByIdAsync(int saleId)
        {

        }
        public async Task<bool> UpdateSaleAsync(SaleEdit model)
        {

        }
        public async Task<bool> DeleteSaleAsync(int saleId)
        {

        }
    }
}
