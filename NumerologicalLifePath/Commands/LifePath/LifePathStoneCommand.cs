using NumerologicalLifePath.Sdk.Abstractions;

namespace NumerologicalLifePath.Sdk.Commands.LifePath;

public sealed class LifePathStoneCommand() : ACommand<short>()
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

        if (!Client!.BirthDate.HasValue)
            throw new InvalidOperationException("The birthdate is null.");

        sum += Client.BirthDate.Value.Day;
        sum += Client.BirthDate.Value.Month;
        sum += Client.BirthDate.Value.Year;

        foreach (var digit in sum.ToString())
            result.Add(digit);

        return [.. result];
    }
}
