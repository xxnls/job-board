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
    public class JobsController : ControllerBase
    {
        private readonly JobBoardDbContext _context;

        public JobsController(JobBoardDbContext context)
        {
            _context = context;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetJobs()
        {
            var jobs = await _context.Jobs
                .Include(j => j.JobLocations)
                    .ThenInclude(jl => jl.Location)
                .Include(j => j.JobCategories)
                    .ThenInclude(jc => jc.Category)
                .Include(j => j.Company)
                .Where(j => j.IsActive)
                .ToListAsync();

            return jobs.Select(job => new JobDto
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                WorkModel = job.WorkModel,
                ContractType = job.ContractType,
                Salary = job.Salary,
                CompanyName = job.Company.Name,
                CategoryNames = job.JobCategories.Select(jc => jc.Category.Name).ToList(),
                LocationNames = job.JobLocations.Select(jl => $"{jl.Location.City}, {jl.Location.Country}").ToList()
            }).ToList();
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDto>> GetJob(int id)
        {
            var job = await _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.JobLocations)
                    .ThenInclude(jl => jl.Location)
                .Include(j => j.JobCategories)
                    .ThenInclude(jc => jc.Category)
                .FirstOrDefaultAsync(j => j.Id == id && j.IsActive);

            if (job == null)
            {
                return NotFound();
            }

            var jobDto = new JobDto
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                WorkModel = job.WorkModel,
                ContractType = job.ContractType,
                Salary = job.Salary,
                CompanyName = job.Company?.Name ?? "N/A",
                CategoryNames = job.JobCategories.Select(jc => jc.Category?.Name).ToList(),
                LocationNames = job.JobLocations.Select(jl => $"{jl.Location?.City}, {jl.Location?.Country}").ToList()
            };

            return jobDto;
        }


        // PUT: api/Jobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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

        // POST: api/Jobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(JobCreateDto jobDto)
        {
            // 1. Validate Company
            var company = await _context.Companies.FindAsync(jobDto.CompanyId);
            if (company == null || !company.IsActive)
            {
                return BadRequest("Invalid CompanyId or Company is inactive.");
            }

            // 2. Validate Locations
            var validLocationIds = await _context.Locations
                .Where(l => jobDto.LocationIds.Contains(l.Id) && l.IsActive)
                .Select(l => l.Id)
                .ToListAsync();

            if (validLocationIds.Count != jobDto.LocationIds.Count)
            {
                return BadRequest("One or more LocationIds are invalid.");
            }

            // 3. Validate Categories
            var validCategoryIds = await _context.Categories
                .Where(c => jobDto.CategoryIds.Contains(c.Id) && c.IsActive)
                .Select(c => c.Id)
                .ToListAsync();

            if (validCategoryIds.Count != jobDto.CategoryIds.Count)
            {
                return BadRequest("One or more CategoryIds are invalid.");
            }

            // 4. Create Job with Valid Data
            var newJob = new Job
            {
                Title = jobDto.Title,
                Description = jobDto.Description,
                WorkModel = jobDto.WorkModel,
                ContractType = jobDto.ContractType,
                Salary = jobDto.Salary,
                CompanyId = jobDto.CompanyId,

                // Initialize navigation properties with valid IDs
                JobLocations = validLocationIds.Select(locationId => new JobLocation { LocationId = locationId }).ToList(),
                JobCategories = validCategoryIds.Select(categoryId => new JobCategory { CategoryId = categoryId }).ToList()
            };

            _context.Jobs.Add(newJob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJob", new { id = newJob.Id }, newJob);
        }


        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            job.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
