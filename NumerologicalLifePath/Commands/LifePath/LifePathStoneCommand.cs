using NumerologicalLifePath.Sdk.Abstractions;

namespace NumerologicalLifePath.Sdk.Commands.LifePath;

public sealed class LifePathStoneCommand() : ACommand()
{
    public override void Execute()
    {
        base.Execute();
        var inputDatas = GetInputDatas();
        _result = Treatments.DigitAggregate(string.Join("", inputDatas));
    }

    private char[] GetInputDatas()
    {
        var sum = 0;
        var result = new List<char>();

        sum += Client!.BirthDate.Day;
        sum += Client!.BirthDate.Month;
        sum += Client!.BirthDate.Year;

        foreach (var digit in sum.ToString())
            result.Add(digit);

        return [.. result];
    }
}
