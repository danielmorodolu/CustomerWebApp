using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileService.Models;

namespace ProfileService.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
public async Task<IActionResult> GetProfile(int id)
{
    var profile = await _context.Profiles.FindAsync(id);
    if (profile == null)
    {
        return NotFound();
    }
    return Ok(profile);
}


        [HttpPost]
        public async Task<IActionResult> CreateProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profile);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, Profile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
