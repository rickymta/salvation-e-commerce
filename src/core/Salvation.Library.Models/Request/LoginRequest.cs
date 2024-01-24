namespace Salvation.Library.Models.Request;

public class LoginRequest
{
    public string IpAddress { get; set; } = null!;

    public string Email { get; set; } = null!;
 
    public string Password { get; set; } = null!;
}
