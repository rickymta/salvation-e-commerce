namespace Salvation.Library.Models.Response;

public class LoginResponse
{
    public string Email { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public string AccessToken { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}
