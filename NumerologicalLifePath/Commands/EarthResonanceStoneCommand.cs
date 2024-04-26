namespace NumerologicalLifePath.Commands;

public sealed class EarthResonanceStoneCommand(Client client) : ACommand(client)
{
    public override void Execute()
    {
        _result = ((Int16)_client.BirthDate.Year).NumerologicalResonance();
    }

    protected override char[] GetInputDatas() => throw new NotImplementedException();
}
