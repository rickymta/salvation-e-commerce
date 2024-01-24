﻿namespace Salvation.Library.Models.Jwt;

public class JwtHeader
{
    /// <summary>
    /// Loại JWT
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// Thuật toán mã hoá JWT Signature
    /// </summary>
    public string Alogrithm { get; set; } = null!;
}
