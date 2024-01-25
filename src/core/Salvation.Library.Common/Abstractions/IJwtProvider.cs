using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Jwt.Enums;

namespace Salvation.Library.Common.Abstractions;

/// <summary>
/// IJwtProvider
/// </summary>
public interface IJwtProvider
{
    /// <summary>
    /// GenerateJwt
    /// </summary>
    /// <param name="account"></param>
    /// <param name="role"></param>
    /// <param name="sub"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public string? GenerateJwt(Account account, string role, string sub, JwtType type);

    /// <summary>
    /// ValidateJwt
    /// </summary>
    /// <param name="jwt"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public bool ValidateJwt(string jwt, JwtType type);
}
