using InventoryManagementBlazor.Shared.Models.Locations;
namespace InventoryManagementBlazor.Server.Services.Locations
{
    public interface ILocationServices
    {
        Task<IEnumerable<LocationListItem>> GetAllLocationsAsync();
        Task<bool> CreateLocationAsync(LocationCreate model);
        Task<LocationDetail> GetLocationByIdAsync(int locationId);
        Task<bool> UpdateLocationAsync(LocationEdit model);
        Task<bool> DeleteLocationAsync(int locationId);
    }
}
