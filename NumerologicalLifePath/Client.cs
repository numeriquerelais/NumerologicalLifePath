using System.Collections.Immutable;

namespace NumerologicalLifePath.Sdk;

public sealed class Client
{
    public readonly ImmutableList<string>? FirstNames;
    public readonly ImmutableList<string>? LastNames;
    public readonly DateOnly? BirthDate;

    public Client(DateOnly birthDate) {
        BirthDate = birthDate;
    }

    public Client(string firstNames, string lastNames, string separator = " ")
    {
        FirstNames = [.. firstNames.Trim().Split(separator)];
        LastNames = [.. lastNames.Trim().Split(separator)];
    }

    public Client(DateOnly birthDate, string firstNames, string lastNames, string separator = " ")
    {
        BirthDate = birthDate;
        FirstNames = string.IsNullOrWhiteSpace(firstNames)? null:[.. firstNames.Trim().Split(separator)];
        LastNames = string.IsNullOrWhiteSpace(lastNames) ? null : [.. lastNames.Trim().Split(separator)];
    }
}
