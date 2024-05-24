using System.Collections.Immutable;

namespace NumerologicalLifePath.Sdk;
public sealed class Client
{
    public readonly ImmutableList<string>? FirstNames;
    public readonly ImmutableList<string>? LastNames;
    public readonly DateOnly BirthDate; //TODO : should be nullable

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
        FirstNames = [.. firstNames.Trim().Split(separator)];
        LastNames = [.. lastNames.Trim().Split(separator)];
    }

    public Client(DateOnly birthDate, ImmutableList<string>? firstNames = null, ImmutableList<string>? lastNames = null) {
        BirthDate = birthDate;
        FirstNames = firstNames != null ? [.. firstNames?.Select(elmt => elmt.Trim())] : null;
        LastNames = lastNames != null ? [.. lastNames?.Select(elmt => elmt.Trim())] : null; ;
    }
}
