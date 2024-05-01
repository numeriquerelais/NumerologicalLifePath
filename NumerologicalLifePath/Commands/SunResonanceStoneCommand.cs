namespace NumerologicalLifePath.Commands;

public sealed class SunResonanceStoneCommand() : ACommand()
{
    public override void Execute()
    {
        _result = ((Int16)Client.BirthDate.Month).NumerologicalResonance();
    }

    protected override char[] GetInputDatas() => throw new NotImplementedException();
}
