using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Auth;

public class ChangePasswordModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }
}
