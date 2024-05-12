namespace NumerologicalLifePath.Commands;

public sealed class MoonResonanceStoneCommand() : ACommand()
{
    public override void Execute()
    {
        base.Execute();
        _result = ((Int16)Client!.BirthDate.Day).NumerologicalResonance();
    }

    protected override char[] GetInputDatas() => throw new NotImplementedException();
}
