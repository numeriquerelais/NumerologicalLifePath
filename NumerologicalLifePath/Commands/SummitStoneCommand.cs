namespace NumerologicalLifePath.Commands;

public sealed class SummitStoneCommand() : ACommand()
{
    public override void Execute()
    {
        var inputDatas = GetInputDatas();
        _result = Treatments.CharAggregate(inputDatas);
    }

    protected override char[] GetInputDatas()
    {
        var result = new List<char>();

        try
        {
            foreach (var firstName in Client.FirstNames)
                result.Add(firstName[^1]);

            foreach (var lastName in Client.LastNames)
                result.Add(lastName[^1]);
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentException("Client first names and/or last names lists are empties.");
        }

        return [.. result];
    }
}
