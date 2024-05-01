namespace NumerologicalLifePath.Commands;

public sealed class EarthResonanceStoneCommand() : ACommand()
{
    public override void Execute()
    {
        _result = ((Int16)Client.BirthDate.Year).NumerologicalResonance();
    }

    protected override char[] GetInputDatas() => throw new NotImplementedException();
}
