namespace NumerologicalLifePath.Commands;

public sealed class SunResonanceStoneCommand(Client client) : ACommand(client)
{
    public override void Execute()
    {
        _result = ((Int16)_client.BirthDate.Month).NumerologicalResonance();
    }

    protected override char[] GetInputDatas() => throw new NotImplementedException();
}
