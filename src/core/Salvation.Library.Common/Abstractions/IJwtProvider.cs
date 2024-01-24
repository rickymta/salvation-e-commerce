using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Jwt.Enums;

namespace Salvation.Library.Common.Abstractions;

/// <summary>
/// IJwtProvider
/// </summary>
public interface IJwtProvider
{
    public string? GenerateJwt(Account account, string role, string sub, JwtType type);

    public bool ValidateJwt(string jwt, JwtType type);
}
