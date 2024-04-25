using NumerologicalLifePath.Commands;

namespace NumerologicalLifePath.CompoundCommands
{
    public sealed class TouchStoneCompoundCommand(Client client, bool reduceAggregate=true) : 
        ACompoundCommand(new List<ICommand>() {
            new ExpressionStoneCompoundCommand(client, false),
            new FoundationStoneCommand(client), 
            new SummitStoneCommand(client),
            new CallingStoneCommand(client, false),
            new PersonnalityStoneCommand(client, false),            
        }, reduceAggregate)
    {}
}
