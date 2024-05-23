using NumerologicalLifePath.Sdk.Abstractions;
using NumerologicalLifePath.Sdk.Commands.LifePath;

namespace NumerologicalLifePath.Sdk.CompoundCommands.LifePath;

public sealed class TouchStoneCompoundCommand(bool reduceAggregate = true) :
    ACompoundCommand(new List<ICommand>() {
        new ExpressionStoneCompoundCommand(false),
        new FoundationStoneCommand(),
        new SummitStoneCommand(),
        new CallingStoneCommand(false),
        new PersonnalityStoneCommand(false),
    }, reduceAggregate)
{ }
