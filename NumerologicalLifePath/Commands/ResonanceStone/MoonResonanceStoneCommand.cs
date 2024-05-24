using NumerologicalLifePath.Sdk.Abstractions;

namespace NumerologicalLifePath.Sdk.Commands.ResonanceStone;

public sealed class MoonResonanceStoneCommand() : ACommand<short>()
{
    public override void Execute()
    {
        base.Execute();
        _result = ((short)Client!.BirthDate.Day).NumerologicalResonance();
    }
}
