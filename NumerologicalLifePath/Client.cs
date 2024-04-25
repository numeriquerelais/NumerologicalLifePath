using System.Collections.Immutable;

namespace NumerologicalLifePath;
public sealed class Client(ImmutableList<string> firstNames, ImmutableList<string> lastNames, DateOnly birthDate)
{
    public readonly ImmutableList<string> FirstNames = firstNames;
    public readonly ImmutableList<string> LastNames = lastNames;
    public readonly DateOnly BirthDate = birthDate;
}
