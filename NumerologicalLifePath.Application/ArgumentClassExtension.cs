using System.CommandLine;
using System.CommandLine.Parsing;

namespace NumerologicalLifePath.Application;

public static class ArgumentClassExtension
{
    public static DateOnly ConvertArgToDateOnly(this System.CommandLine.Parsing.ArgumentResult result)
    {
        string? input = result.Tokens.FirstOrDefault()?.Value.Replace("-", "/").Replace(".", "/");

        if (!DateOnly.TryParseExact(input, "dd/MM/yyyy", out DateOnly date))
            if (!DateOnly.TryParseExact(input, "MM/dd/yyyy", out date))
                if (!DateOnly.TryParseExact(input, "yyyy/MM/dd", out date))
                    throw new CannotParseException($"Cannot parse argument '{input}' as expected type 'System.DateOnly'.");
        return date;
    }
}
