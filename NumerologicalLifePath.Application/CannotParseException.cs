namespace NumerologicalLifePath.Application;

public sealed class CannotParseException(string? message) : ArgumentException(message)
{
}
