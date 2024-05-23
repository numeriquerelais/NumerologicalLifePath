using System.Collections.Immutable;

namespace NumerologicalLifePath.Sdk;
public sealed class Client(DateOnly birthDate, ImmutableList<string>? firstNames = null, ImmutableList<string>? lastNames = null)
{
    public readonly ImmutableList<string>? FirstNames = firstNames;
    public readonly ImmutableList<string>? LastNames = lastNames;
    public readonly DateOnly BirthDate = birthDate;
}
