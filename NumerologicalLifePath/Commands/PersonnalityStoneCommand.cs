namespace NumerologicalLifePath.Commands;

public sealed class PersonnalityStoneCommand(Client client, bool reduceAggrgate = true) : ACommand(client)
{
    private readonly bool _reduceAggrgate = reduceAggrgate;

    public override void Execute()
    {
        var inputDatas = GetInputDatas();

        if (inputDatas.Length == 0)
            throw new ArgumentException("No consonant found.");

        _result = Treatments.CharAggregate(inputDatas, _reduceAggrgate);
    }

    protected override char[] GetInputDatas()
    {
        var letters = (string.Join("", _client.FirstNames) + string.Join("", _client.LastNames)).ToCharArray().Where(letter => Treatments.IsConsonant(letter)).ToArray();
        return [.. letters];
    }
}
