using Duende.IdentityServer.EntityFramework.Options;
using InventoryManagementBlazor.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InventoryManagementBlazor.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }
        public DbSet<SaleEntity> Sales { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }

    }
}