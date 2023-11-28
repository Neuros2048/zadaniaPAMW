using System.ComponentModel.DataAnnotations;

namespace WebLiblary.Auth;

public class UserLoginDTO
{
    
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}