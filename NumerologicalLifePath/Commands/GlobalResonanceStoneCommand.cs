namespace NumerologicalLifePath.Commands;

public sealed class GlobalResonanceStoneCommand() : ACommand()
{
    public override void Execute()
    {
        base.Execute();
        _result = Client!.BirthDate.NumerologicalResonance();
    }
}
