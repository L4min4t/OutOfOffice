using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Token;

public class RefreshTokenModel : TokenModel
{
    [Required]
    public string Email { get; set; }
}