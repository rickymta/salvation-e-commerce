using System.Net;

namespace Salvation.Library.Controller.Middlewares.Exceptions;

/// <summary>
/// ExcMidResult
/// </summary>
public class ExcMidResult
{
    public HttpStatusCode ErrorCode { get; set; }

    public string ErrorStatus { get; set; }

    public string ErrorMessage { get; set; }

    public string ErrorDetails { get; set; }

    public string? StackTrace { get; set; }
}
