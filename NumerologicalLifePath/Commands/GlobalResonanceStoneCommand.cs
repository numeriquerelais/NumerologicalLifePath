namespace NumerologicalLifePath.Commands;

public sealed class GlobalResonanceStoneCommand() : ACommand()
{
    public override void Execute()
    {
        _result = Client.BirthDate.NumerologicalResonance();
    }

    protected override char[] GetInputDatas() => throw new NotImplementedException();
}
