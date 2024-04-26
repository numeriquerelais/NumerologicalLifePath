namespace NumerologicalLifePath.Commands;

public sealed class GlobalResonanceStoneCommand(Client client) : ACommand(client)
{
    public override void Execute()
    {
        _result = client.BirthDate.NumerologicalResonance();
    }

    protected override char[] GetInputDatas() => throw new NotImplementedException();
}
