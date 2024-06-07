using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoard.API.Data;
using JobBoard.API.Models;
using JobBoard.API.Dtos;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly JobBoardDbContext _context;
        private readonly IMapper _mapper;

        public CompaniesController(JobBoardDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var companies = await _context.Companies
                .Include(c => c.Locations)
                .Include(c => c.Jobs).ThenInclude(j => j.Categories)
                .Include(c => c.Jobs).ThenInclude(j => j.Locations)
                .ToListAsync();

            if (companies == null)
            {
                return NotFound();
            }

            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return Ok(companiesDto);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(long id)
        {
            var company = await _context.Companies
                .Include(c => c.Locations)
                .Include(c => c.Jobs).ThenInclude(j => j.Categories)
                .Include(c => c.Jobs).ThenInclude(j=> j.Locations)
                .FirstOrDefaultAsync(c => c.Id == id); 

            if (company == null)
            {
                return NotFound();
            }

            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(companyDto);
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(long id, Company company)
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
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            _context.Companies.Add(company);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompanyExists(company.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(long id)
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

        private bool CompanyExists(long id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
