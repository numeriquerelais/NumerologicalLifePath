namespace NumerologicalLifePath.Commands;

public sealed class LifePathStoneCommand(Client client) : ACommand(client)
{
    public override void Execute()
    {
        var inputDatas = GetInputDatas();
        _result = Treatments.DigitAggregate(string.Join("",inputDatas));
    }

    protected override char[] GetInputDatas()
    {
        var sum = 0;
        var result = new List<char>();

        sum += _client.BirthDate.Day;
        sum += _client.BirthDate.Month;
        sum += _client.BirthDate.Year;

        foreach (var digit in sum.ToString())
            result.Add(digit);

        return [.. result];
    }
}
