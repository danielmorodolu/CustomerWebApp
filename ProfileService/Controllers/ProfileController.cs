using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProfileService.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;




namespace ProfileService.Controllers

{
[Authorize]
public class ProfileController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProfileController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Profile
    public async Task<IActionResult> Index()
    {
        var profiles = await _context.Profiles.ToListAsync();
        return View(profiles);
    }

    // GET: /Profile/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Profile/Create
    [HttpPost]
    public async Task<IActionResult> Create(Profile profile)
    {
        if (ModelState.IsValid)
        {
            _context.Add(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(profile);
    }

    // GET: /Profile/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var profile = await _context.Profiles.FindAsync(id);
        if (profile == null) return NotFound();
        return View(profile);
    }

    // POST: /Profile/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Profile profile)
    {
        if (id != profile.Id) return BadRequest();
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(profile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Profiles.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }
        }
        return View(profile);
    }

    // GET: /Profile/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var profile = await _context.Profiles.FindAsync(id);
        if (profile == null) return NotFound();
        return View(profile);
    }

    // POST: /Profile/DeleteConfirmed
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var profile = await _context.Profiles.FindAsync(id);
        if (profile != null)
        {
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: /Profile/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var profile = await _context.Profiles.FindAsync(id);
        if (profile == null) return NotFound();
        return View(profile);
    }
}
}