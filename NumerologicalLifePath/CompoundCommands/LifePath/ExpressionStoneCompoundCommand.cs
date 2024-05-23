using NumerologicalLifePath.Sdk.Abstractions;
using NumerologicalLifePath.Sdk.Commands.LifePath;

namespace NumerologicalLifePath.Sdk.CompoundCommands.LifePath
{
    public sealed class ExpressionStoneCompoundCommand(bool reduceAggregate = true) :
        ACompoundCommand(new List<ICommand>() {
            new CallingStoneCommand(false),
            new PersonnalityStoneCommand(false)
        }, reduceAggregate)
    {
    }
}
