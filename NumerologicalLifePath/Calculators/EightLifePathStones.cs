using NumerologicalLifePath.Commands;
using NumerologicalLifePath.CompoundCommands;

namespace NumerologicalLifePath.Calculators;

public sealed class EightLifePathStones : ACalculator
{
    public EightLifePathStones() : 
        base(new Calculator([
            new FoundationStoneCommand(),
            new SummitStoneCommand(),
            new LifePathStoneCommand(),
            new CallingStoneCommand(),
            new PersonnalityStoneCommand(),
            new ExpressionStoneCompoundCommand(),
            new TouchStoneCompoundCommand(),
            new WishStoneCommand()
        ]))
    { }
}
