using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoard.API.Models;
using AutoMapper;
using JobBoard.API.Dtos;

namespace JobBoard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly JobBoardDbContext _context;
        private readonly IMapper _mapper;  // Inject IMapper

        public JobsController(JobBoardDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetJobs()
        {
            var jobs = await _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.Categories)
                .Include(j => j.Locations)
                .ToListAsync();

            if (jobs == null)
            {
                return NotFound();
            }

            var jobDtos = _mapper.Map<IEnumerable<JobDto>>(jobs);
            return Ok(jobDtos);
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDto>> GetJob(long id)
        {
            var job = await _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.Categories)
                .Include(j => j.Locations)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            var jobDto = _mapper.Map<JobDto>(job);
            return Ok(jobDto);
        }

        // PUT: api/Jobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(long id, Job job)
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
        public async Task<ActionResult<Job>> PostJob(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJob", new { id = job.Id }, job);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(long id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobExists(long id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
