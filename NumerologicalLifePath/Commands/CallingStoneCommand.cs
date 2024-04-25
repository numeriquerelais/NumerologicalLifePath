namespace NumerologicalLifePath.Commands;

public sealed class CallingStoneCommand(Client client, bool reduceAggregate = true) : ACommand(client)
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
        var letters = (string.Join("", _client.FirstNames) + string.Join("", _client.LastNames)).ToCharArray().Where(letter => Treatments.IsVowel(letter)).ToArray();
        return [.. letters];
    }
}
