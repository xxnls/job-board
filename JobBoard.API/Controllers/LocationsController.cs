﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoard.API.Models;
using JobBoard.API.Dtos;

namespace JobBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly JobBoardDbContext _context;

        public LocationsController(JobBoardDbContext context)
        {
            _context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            return await _context.Locations.Where(l => l.IsActive).ToListAsync();
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id && l.IsActive);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(LocationCreateDto locationDto)
        {
            // Check for duplicate location before creation
            var existingLocation = await _context.Locations.FirstOrDefaultAsync(l =>
                l.Country == locationDto.Country &&
                l.Region == locationDto.Region &&
                l.City == locationDto.City &&
                l.PostalCode == locationDto.PostalCode &&
                l.Address == locationDto.Address
            );

            if (existingLocation != null)
            {
                return Conflict("A location with the same details already exists.");
            }
            else
            {
                var newLocation = new Location
                {
                    Country = locationDto.Country,
                    Region = locationDto.Region,
                    City = locationDto.City,
                    PostalCode = locationDto.PostalCode,
                    Address = locationDto.Address
                };

                _context.Locations.Add(newLocation);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetLocation", new { id = newLocation.Id }, newLocation);
            }
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            location.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.Id == id);
        }
    }
}
