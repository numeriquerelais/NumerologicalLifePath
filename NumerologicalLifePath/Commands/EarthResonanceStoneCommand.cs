namespace NumerologicalLifePath.Commands;

public sealed class EarthResonanceStoneCommand() : ACommand()
{
    public override void Execute()
    {
        base.Execute();
        _result = ((Int16)Client!.BirthDate.Year).NumerologicalResonance();
    }
}
