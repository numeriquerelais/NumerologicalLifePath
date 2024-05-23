using NumerologicalLifePath.Sdk.Abstractions;

namespace NumerologicalLifePath.Sdk.Commands.LifePath;

public sealed class FoundationStoneCommand() : ACommandWithImputs()
{
    public override void Execute()
    {
        base.Execute();
        var inputDatas = GetInputDatas();
        _result = Treatments.CharAggregate(inputDatas);
    }

    protected override char[] GetInputDatas()
    {
        var result = new List<char>();
        List<string> tmp;

        if (Client?.FirstNames != null)
        {
            tmp = Client.FirstNames.Where(f => !string.IsNullOrEmpty(f.Trim())).ToList();
            foreach (var firstName in tmp)
                result.Add(firstName[0]);
        }

        if (Client?.LastNames != null)
        {
            tmp = Client.LastNames.Where(f => !string.IsNullOrEmpty(f.Trim())).ToList();
            foreach (var lastName in tmp)
                result.Add(lastName[0]);
        }

        if (result.Count == 0)
            throw new ArgumentException("Client first names and/or last names lists are empties.");

        return [.. result];
    }
}
