using InventoryManagementBlazor.Server.Services.Locations;
using InventoryManagementBlazor.Shared.Models.Locations;
using InventoryManagementBlazor.Shared.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementBlazor.Server.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationServices _locationServices;
        public LocationController(ILocationServices locationServices)
        {
            _locationServices = locationServices;   
        }
        public async Task<IActionResult> Index()
        {
            var locations = await _locationServices.GetAllLocationsAsync();
            return Ok(locations);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Location(int id)
        {
            var location = await _locationServices.GetLocationByIdAsync(id);
            if(location == null) return NotFound();
            return Ok(location);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LocationCreate model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            bool wasSuccessful = await _locationServices.CreateLocationAsync(model);
            if (wasSuccessful) return Ok();
            return UnprocessableEntity();
        }
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, LocationEdit model)
        {
            
            if (model == null || !ModelState.IsValid) return BadRequest();
                        bool wasSuccessful = await _locationServices.UpdateLocationAsync(model);
            if (wasSuccessful) return Ok();
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var location = await _locationServices.GetLocationByIdAsync(id);
            if (location == null) return NotFound();
            bool wasSuccessful = await _locationServices.DeleteLocationAsync(id);
            if (!wasSuccessful) return BadRequest();
            return Ok();
        }
    }
}
