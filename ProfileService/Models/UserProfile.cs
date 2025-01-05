
namespace ProfileService.Models
{
public class UserProfile
{
    public int Id { get; set; }
    public string? UserId { get; set; } // Auth0 User ID
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}
}