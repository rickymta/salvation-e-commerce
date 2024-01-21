namespace Salvation.Library.Models.Request
{
    public class RegisterRequest
    {
        public string Fullname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string? Address { get; set; }
    }
}
