namespace NumerologicalLifePath.Commands;

public sealed class MoonResonanceStoneCommand(Client client) : ACommand(client)
{
    public override void Execute()
    {
        _result = ((Int16)_client.BirthDate.Day).NumerologicalResonance();
    }

    protected override char[] GetInputDatas() => throw new NotImplementedException();
}
