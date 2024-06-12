using Backend.Lists.Employees;

namespace Backend.Lists;

public class User : Microsoft.AspNetCore.Identity.IdentityUser, IEntity
{
    public int Id { get; set; }
    
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}