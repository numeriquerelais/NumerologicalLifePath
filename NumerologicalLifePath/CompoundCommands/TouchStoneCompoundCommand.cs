using NumerologicalLifePath.Commands;

namespace NumerologicalLifePath.CompoundCommands
{
    public sealed class TouchStoneCompoundCommand(bool reduceAggregate=true) : 
        ACompoundCommand(new List<ICommand>() {
            new ExpressionStoneCompoundCommand(false),
            new FoundationStoneCommand(), 
            new SummitStoneCommand(),
            new CallingStoneCommand(false),
            new PersonnalityStoneCommand(false),            
        }, reduceAggregate)
    {}
}
