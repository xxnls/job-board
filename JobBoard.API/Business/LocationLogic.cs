using JobBoard.API.Models;
using JobBoard.API.Dtos;

namespace JobBoard.API.Business
{
    public class LocationLogic
    {
        private readonly JobBoardDbContext _context;

        public LocationLogic(JobBoardDbContext context)
        {
            _context = context;
        }

        public async Task<List<LocationCreateDto>> SearchLocationsAsync(string query)
        {
            // Normalize the query for case-insensitive search
            query = query.ToLower();

            // Search across multiple fields (City, Region, PostalCode, Country)
            var locations = _context.Locations
                .Where(l => l.City.ToLower().Contains(query)
                         || l.Region.ToLower().Contains(query)
                         || l.PostalCode.ToLower().Contains(query)
                         || l.Country.ToLower().Contains(query)
                         || l.Address.ToLower().Contains(query))
                .Select(l => new LocationCreateDto
                {
                    Id = l.Id,
                    City = l.City,
                    Region = l.Region,
                    PostalCode = l.PostalCode,
                    Country = l.Country,
                    Address = l.Address,
                    IsActive = true
                })
                .ToList();

            return locations;
        }
    }
}