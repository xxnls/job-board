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
    public class PeopleController : ControllerBase
    {
        private readonly JobBoardDbContext _context;
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

        public PeopleController(JobBoardDbContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            return await _context.People.Where(l => l.IsActive).ToListAsync();
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.People.FirstOrDefaultAsync(l => l.Id == id && l.IsActive);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(PersonCreateDto personDto)
        {
            // 1. Generate random username
            string userName = GenerateRandomUserName();
            while (await _context.Users.AnyAsync(u => u.UserName == userName))
            {
                userName = GenerateRandomUserName();
            }

            // 2. Create User 
            var newUser = new User
            {
                UserName = userName,
                Email = personDto.Email,
                Password = personDto.Password // Hash/encrypt in later stages
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync(); // Save user first to get the ID

            // 3. Create Person 
            var newPerson = new Person
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                LocationId = personDto.LocationId,
                UserId = newUser.Id // Associate User with Person using UserId
            };

            _context.People.Add(newPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = newPerson.Id }, newPerson);
        }


        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            person.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
