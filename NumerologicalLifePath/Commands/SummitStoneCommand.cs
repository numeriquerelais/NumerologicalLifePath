namespace NumerologicalLifePath.Commands;

public sealed class SummitStoneCommand() : ACommandWithImputs()
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

        if (Client?.FirstNames != null)
        {
            var firstNames = Client.FirstNames.Where(f => !String.IsNullOrWhiteSpace(f.Trim())).ToList();
            foreach (var firstName in firstNames)
                result.Add(firstName[^1]);
        }

        if (Client?.LastNames != null)
        {
            var lastNames = Client.LastNames.Where(l => !String.IsNullOrWhiteSpace(l.Trim())).ToList();
            foreach (var lastName in lastNames)
                result.Add(lastName[^1]);
        }

        if (result.Count == 0)
            throw new ArgumentException("Client first names and/or last names lists are empties.");

        return [.. result];
    }
}
