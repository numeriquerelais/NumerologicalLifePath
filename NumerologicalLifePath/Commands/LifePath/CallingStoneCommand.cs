using NumerologicalLifePath.Sdk.Abstractions;

namespace NumerologicalLifePath.Sdk.Commands.LifePath;

public sealed class CallingStoneCommand(bool reduceAggregate = true) : ACommandWithImputs()
{
    private readonly bool _reduceAggregate = reduceAggregate;
    public override void Execute()
    {
        base.Execute();
        var inputDatas = GetInputDatas();

        if (inputDatas.Length == 0)
            throw new ArgumentException("No vowel found.");

        _result = Treatments.CharAggregate(inputDatas, _reduceAggregate);
    }

    protected override char[] GetInputDatas()
    {
        string letters = string.Concat(string.Join("", Client?.FirstNames ?? []), string.Join("", Client?.LastNames ?? []));

        var results = letters.ToCharArray().Where(letter => Treatments.IsVowel(letter)).ToArray();
        return [.. results];
    }
}
