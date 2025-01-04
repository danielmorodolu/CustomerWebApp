using Microsoft.EntityFrameworkCore;

namespace ProfileService.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Profile> Profiles { get; set; }
    }

    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
