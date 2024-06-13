using System;
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
    public class CompaniesController : ControllerBase
    {
        private readonly JobBoardDbContext _context;

        public CompaniesController(JobBoardDbContext context)
        {
            _context = context;
        }

        private string GenerateRandomUserName()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            var random = new Random();
            var randomLetters = new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            var randomNumbers = new string(Enumerable.Repeat(numbers, 3)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomLetters + randomNumbers;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _context.Companies.Where(c => c.IsActive).ToListAsync();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == id && c.IsActive);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(CompanyCreateDto companyDto)
        {
            // 1. Generate Random Username (same as before)
            string userName = GenerateRandomUserName();
            while (await _context.Users.AnyAsync(u => u.UserName == userName))
            {
                userName = GenerateRandomUserName();
            }

            // 2. Create User 
            var newUser = new User
            {
                UserName = userName,
                Email = companyDto.Email,
                Password = companyDto.Password // Hash in production!
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync(); // Save user first to get the ID

            // 3. Create Company 
            var newCompany = new Company
            {
                Name = companyDto.Name,
                Description = companyDto.Description,
                UserId = newUser.Id
            };
            _context.Companies.Add(newCompany);
            await _context.SaveChangesAsync();

            // 4. Create Entries in the Join Table
            foreach (var locationId in companyDto.LocationIds)
            {
                _context.CompanyLocations.Add(new CompanyLocation
                {
                    CompanyId = newCompany.Id, // Use the newly generated CompanyId
                    LocationId = locationId
                });
            }

            await _context.SaveChangesAsync(); // Save the join table entries

            return CreatedAtAction("GetCompany", new { id = newCompany.Id }, newCompany);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
