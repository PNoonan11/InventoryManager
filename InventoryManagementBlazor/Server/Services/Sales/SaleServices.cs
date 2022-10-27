using InventoryManagementBlazor.Server.Data;
using InventoryManagementBlazor.Server.Models;
using InventoryManagementBlazor.Shared.Models.Sales;
using Microsoft.EntityFrameworkCore;

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
                DateOfSale = DateTimeOffset.Now,
                CustomerSoldTo = model.CustomerSoldTo,
                SoldByUserId = model.SoldByUserId
            };
            _context.Sales.Add(newSaleEntry);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<IEnumerable<SaleListItem>> GetAllSalesAsync()
        {
            var saleQuery = _context.Sales.Select(r => new SaleListItem
            {
                Id = r.Id,
                ProductSold = r.ProductSold,
                ProductId = r.ProductId,
                ProductQuantitySold = r.ProductQuantitySold,
                LocationSoldFrom = r.LocationSoldFrom,
                DateOfSale = r.DateOfSale,
                CustomerSoldTo = r.CustomerSoldTo,
                SoldByUserId = r.SoldByUserId
            });
            return await saleQuery.ToListAsync();
        }
        public async Task<SaleDetail> GetSaleByIdAsync(int saleId)
        {
            var salesFromDB = await _context.Sales.FirstOrDefaultAsync(r => r.Id == saleId);
            if (salesFromDB == null)
                return null;
            var detail = new SaleDetail
            {
                Id = salesFromDB.Id,
                ProductId = salesFromDB.ProductId,
                ProductSold = salesFromDB.ProductSold,
                ProductQuantitySold = salesFromDB.ProductQuantitySold,
                DateOfSale = salesFromDB.DateOfSale,
                LocationSoldFrom = salesFromDB.LocationSoldFrom,
                CustomerSoldTo = salesFromDB.CustomerSoldTo,
                SoldByUserId = salesFromDB.SoldByUserId
            };
            return detail;
        }
        public async Task<bool> UpdateSaleAsync(SaleEdit model)
        {
            if (model == null)
                return false;
            var entity = await _context.Sales.FindAsync(model.Id);
            entity.ProductId = model.ProductId;
                entity.ProductSold = model.ProductSold;
                entity.ProductQuantitySold = model.ProductQuantitySold;                
                entity.LocationSoldFrom = model.LocationSoldFrom;
                entity.CustomerSoldTo = model.CustomerSoldTo;
                entity.SoldByUserId = model.SoldByUserId;
            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<bool> DeleteSaleAsync(int saleId)
        {
            var entity = await _context.Sales.FindAsync(saleId);
            _context.Sales.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
