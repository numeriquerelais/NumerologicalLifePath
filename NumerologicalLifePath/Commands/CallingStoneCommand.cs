namespace NumerologicalLifePath.Commands;

public sealed class CallingStoneCommand(bool reduceAggregate = true) : ACommand()
{
    private readonly bool _reduceAggregate = reduceAggregate;
    public override void Execute()
    {
        var inputDatas = GetInputDatas();

        if (inputDatas.Length == 0)
            throw new ArgumentException("No Vowel found.");

        _result = Treatments.CharAggregate(inputDatas, _reduceAggregate);
    }

    protected override char[] GetInputDatas()
    {
        var letters = (string.Join("", Client!.FirstNames) + string.Join("", Client!.LastNames)).ToCharArray().Where(letter => Treatments.IsVowel(letter)).ToArray();
        return [.. letters];
    }
}
