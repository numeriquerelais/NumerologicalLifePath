namespace NumerologicalLifePath.Application;

public static class ArgumentResultClassExtension
{
    public static DateOnly ConvertArgToDateOnly(this System.CommandLine.Parsing.ArgumentResult result)
    {
        string? input = result.Tokens[0]?.Value.Replace("-", "/").Replace(".", "/");

        if (DateOnly.TryParseExact(input, ["dd/MM/yyyy", "MM/dd/yyyy", "yyyy/MM/dd"], out DateOnly date))
            return date;
        throw new CannotParseArugmentException($"Cannot parse argument '{input}' as expected type 'System.DateOnly'.");
        
    }
}
