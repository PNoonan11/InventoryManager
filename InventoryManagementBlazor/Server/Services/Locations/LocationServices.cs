using InventoryManagementBlazor.Server.Data;
using InventoryManagementBlazor.Server.Models;
using InventoryManagementBlazor.Shared.Models.Locations;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementBlazor.Server.Services.Locations
{
    public class LocationServices : ILocationServices
            {
        private readonly ApplicationDbContext _context;
        public LocationServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateLocationAsync(LocationCreate model)
        {
            if (model == null) return false;
            var locationEntity = new LocationEntity
            {
                Location = model.Location
            };
        _context.Locations.Add(locationEntity);
            return await _context.SaveChangesAsync() == 1;
        }

        public Task<bool> DeleteLocationAsync(int locationId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LocationListItem>> GetAllLocationsAsync()
        {
            var locationQuery = _context.Locations.Select(entity => new LocationListItem
            {
                Id = entity.Id,
                Location = entity.Location
            });
            return await locationQuery.ToListAsync();
        }

        public Task<LocationDetail> GetLocationByIdAsync(int locationId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateLocationAsync(LocationEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
