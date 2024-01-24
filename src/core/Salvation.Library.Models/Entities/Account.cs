namespace Salvation.Library.Models.Entities
{
    public class Account : BaseEntity
    {
        public string Fullname { get; set; } = null!;

        public string Email { get; set; } = null!;
        
        public string Password { get; set; } = null!;
        
        public string? Address { get; set; }
        
        public string? Avatar { get; set; }
    }
}
