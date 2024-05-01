using NumerologicalLifePath.Commands;

namespace NumerologicalLifePath.CompoundCommands
{
    public sealed class ExpressionStoneCompoundCommand(bool reduceAggregate=true) : 
        ACompoundCommand(new List<ICommand>() { 
            new CallingStoneCommand(false), 
            new PersonnalityStoneCommand(false)
        }, reduceAggregate)
    {        
    }
}
