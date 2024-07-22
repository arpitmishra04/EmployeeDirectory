using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LocationController : Controller
    {
        private ILocationService _locationService;
        


        public LocationController(ILocationService locationService)
        {
            this._locationService = locationService;
            
        }
        [HttpGet]
        public IActionResult getLocations()
        {
            List<LocationModel> locations = _locationService.ViewAll();
            return Ok(locations);
        }
    }
}
