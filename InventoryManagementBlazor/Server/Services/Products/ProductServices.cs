using InventoryManagementBlazor.Server.Data;
using InventoryManagementBlazor.Server.Models;
using InventoryManagementBlazor.Shared.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementBlazor.Server.Services.Products
{
    public class ProductServices : IProductServices
    {
        private string _userId;
        private readonly ApplicationDbContext _context;
        public ProductServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateProductAsync(ProductCreate model)
        {
            var productEntity = new ProductEntity
            {
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                StockNumber = model.StockNumber,
                ProductLocation = model.ProductLocation,
                Quantity = model.Quantity,
                DateReceived = DateTimeOffset.Now
            };
            _context.Products.Add(productEntity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        public async Task<IEnumerable<ProductListItem>> GetProductsAsync()
        {
            var productQuery = _context.Products.Select(r => new ProductListItem
            {
                Id = r.Id,
                ProductName = r.ProductName,
                ProductDescription = r.ProductDescription,
                StockNumber = r.StockNumber,
                ProductLocation = r.ProductLocation,
                Quantity = r.Quantity,
                DateReceived = r.DateReceived
            });
            return await productQuery.ToListAsync();
        }
        public async Task<ProductDetail> GetProductByIdAsync(int productId)
        {
            var productEntity = await _context.Products.Include(nameof(Locations)).FirstOrDefaultAsync(r => r.Id == productId);
            if (productEntity is null)
                return null;
            var detail = new ProductDetail
            {
                Id = productEntity.Id,
                ProductName = productEntity.ProductName,
                ProductDescription = productEntity.ProductDescription,
                StockNumber = productEntity.StockNumber,
                ProductLocation = productEntity.ProductLocation,
                Quantity = productEntity.Quantity,
                DateReceived = productEntity.DateReceived,
                DateLastSold = productEntity.DateLastSold
            };
            return detail;
        }
        public async Task<bool> UpdateProductAsync(ProductEdit model)
        {
            if (model == null)
                return false;
            var entity = await _context.Products.FindAsync(model.Id);
            entity.ProductName = model.ProductName;
            entity.ProductDescription = model.ProductDescription;
            entity.StockNumber = model.StockNumber;
            entity.ProductLocation = model.ProductLocation;
            entity.Quantity = model.Quantity;
            entity.DateReceived = model.DateReceived;
            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<bool> DeleteProductAsync(int productId)
        {
            var entity = await _context.Products.FindAsync(productId);
            _context.Products.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }










        public void SetUserId(string userId) => _userId = userId;
    }
}
