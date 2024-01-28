namespace Salvation.Library.Controller.Middlewares.Exceptions;

/// <summary>
/// BadRequestException
/// </summary>
public class BadRequestException : Exception
{
    /// <summary>
    /// BadRequestException
    /// </summary>
    /// <param name="message"></param>
    public BadRequestException(string message) : base(message)
    {
    }
}
