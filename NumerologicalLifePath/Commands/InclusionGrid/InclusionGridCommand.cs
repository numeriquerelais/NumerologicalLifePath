using NumerologicalLifePath.Sdk.Abstractions;

namespace NumerologicalLifePath.Sdk.Commands.InclusionGrid;

public sealed class InclusionGridCommand() : ACommand<short[]>()
{
    public override void Execute()
    {
        base.Execute();
        _result = GetInputDatas();
    }

    private short[] GetInputDatas()
    {
        var results = new short[9];

        var inputs = string.Concat(string.Join("", Client!.FirstNames ?? []), string.Join("", Client!.LastNames ?? [])).Trim();

        if (inputs.Length == 0)
            throw new ArgumentException("Client first names and/or last names lists are empties.");

        foreach (char c in inputs) {
            results[c.ConvertToDigit()-1]++;
        }

        return results;
    }
}