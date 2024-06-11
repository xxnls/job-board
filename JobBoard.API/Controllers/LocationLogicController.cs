using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobBoard.API.Business;
using JobBoard.API.Dtos;
using JobBoard.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace JobBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationLogicController : ControllerBase
    {
        private readonly LocationLogic _locationLogic;

        public LocationLogicController(JobBoardDbContext context)
        {
            _locationLogic = new LocationLogic(context);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<LocationDto>>> SearchLocations([FromQuery] string query)
        {
            try
            {
                var locations = await _locationLogic.SearchLocationsAsync(query);

                // Handle no data found
                if(locations.IsNullOrEmpty()) {
                    return StatusCode(404, query + " not found");
                }

                return Ok(locations);
            }
            catch (ArgumentException ex)
            {
                // Handle invalid query input
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other unexpected errors
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
