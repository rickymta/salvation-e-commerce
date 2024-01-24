namespace Salvation.Library.Models.Jwt;

public class JwtPayload
{
    /// <summary>
    /// Mã người dùng
    /// </summary>
    public string AccountId { get; set; } = null!;

    /// <summary>
    /// Email người dùng
    /// </summary>
    public string Email { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public string Role { get; set; } = null!;

    /// <summary>
    /// Hệ thống sẽ sử dụng token
    /// </summary>
    public string Sub { get; set; } = null!;

    /// <summary>
    /// Thời gian hết hạn
    /// </summary>
    public DateTime Expired { get; set; }
}
