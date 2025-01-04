using Microsoft.EntityFrameworkCore;

namespace ProductService.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }

   public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Initialize
    public string Description { get; set; } = string.Empty; // Initialize
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

}
