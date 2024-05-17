namespace NumerologicalLifePath.Commands;

public sealed class PersonnalityStoneCommand(bool reduceAggrgate = true) : ACommandWithImputs()
{

    private readonly bool _reduceAggrgate = reduceAggrgate;

    public override void Execute()
    {
        base.Execute();
        var inputDatas = GetInputDatas();

        if (inputDatas.Length == 0)
            throw new ArgumentException("No consonant found.");

        _result = Treatments.CharAggregate(inputDatas, _reduceAggrgate);
    }

    protected override char[] GetInputDatas()
    {
        string letters = string.Concat(string.Join("", Client?.FirstNames ?? []), string.Join("", Client?.LastNames ?? []));
        var results = letters.ToCharArray().Where(letter => Treatments.IsConsonant(letter)).ToArray();
        return [.. results];
    }
}
