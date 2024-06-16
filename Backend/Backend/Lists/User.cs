using Microsoft.AspNetCore.Identity;

namespace Backend.Lists;

public class User : IdentityUser
{
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
    
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}
