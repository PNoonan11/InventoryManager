using InventoryManagementBlazor.Shared.Models.Customers;
using InventoryManagementBlazor.Shared.Models.Sales;

namespace InventoryManagementBlazor.Server.Services.Sales
{
    public interface ISaleServices
    {
        Task<bool> CreateSaleAsync(SaleCreate model);
        Task<IEnumerable<SaleListItem>> GetAllSalesAsync();
        Task<SaleDetail> GetSaleByIdAsync(int saleId);
        Task<bool> UpdateSaleAsync(SaleEdit model);
        Task<bool> DeleteSaleAsync(int saleId);
    }
}
