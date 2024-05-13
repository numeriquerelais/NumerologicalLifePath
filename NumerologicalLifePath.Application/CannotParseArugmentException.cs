namespace NumerologicalLifePath.Application;

public sealed class CannotParseArugmentException(string? message) : ArgumentException(message)
{
}
