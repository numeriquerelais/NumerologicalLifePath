using NumerologicalLifePath.Sdk.Abstractions;

namespace NumerologicalLifePath.Sdk.Commands.ResonanceStone;

public sealed class GlobalResonanceStoneCommand() : ACommand<short>()
{
    public override void Execute()
    {
        base.Execute();
        _result = Client!.BirthDate.NumerologicalResonance();
    }
}
