using Salvation.Library.Models.Entities;

namespace Salvation.Library.Models.Cache;

public class AccountCache
{
    public Account AccountData { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}
