using NumerologicalLifePath.Sdk.Abstractions;

namespace NumerologicalLifePath.Sdk.Commands.ResonanceStone;

public sealed class GlobalResonanceStoneCommand() : ACommand<short>()
{
    public override void Execute()
    {
        base.Execute();

        if (!Client!.BirthDate.HasValue)
            throw new InvalidOperationException("The birthdate is null.");

        _result = Client.BirthDate.Value.NumerologicalResonance();
    }
}
