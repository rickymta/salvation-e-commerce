using Microsoft.AspNetCore.Http;

namespace Salvation.Services.Models.Request;

/// <summary>
/// FileUploadRequest
/// </summary>
public class FileUploadRequest
{
    /// <summary>
    /// FileUpload
    /// </summary>
    public IFormFile FileUpload { get; set; } = null!;

    /// <summary>
    /// AccountId
    /// </summary>
    public string? AccountId { get; set; }

    /// <summary>
    /// FileName
    /// </summary>
    public string? FileName { get; set; }

    /// <summary>
    /// FileSalt
    /// </summary>
    public string? FileSalt { get; set; }

    /// <summary>
    /// FileDirectory
    /// </summary>
    public string? FileDirectory { get; set; }

    /// <summary>
    /// ClientSystem
    /// </summary>
    public string? ClientSystem { get; set; }

    /// <summary>
    /// UploadTime
    /// </summary>
    public DateTime? UploadTime { get; set; } = DateTime.Now;
}
