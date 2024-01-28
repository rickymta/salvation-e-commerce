namespace Salvation.Library.Controller.Middlewares.Exceptions;

/// <summary>
/// NotFoundException
/// </summary>
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}
