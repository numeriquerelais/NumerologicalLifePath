using NumerologicalLifePath.Commands;

namespace NumerologicalLifePath.CompoundCommands
{
    public sealed class ExpressionStoneCompoundCommand(Client client, bool reduceAggregate=true) : 
        ACompoundCommand(new List<ICommand>() { 
            new CallingStoneCommand(client, false), 
            new PersonnalityStoneCommand(client, false) 
        }, reduceAggregate)
    {        
    }
}
