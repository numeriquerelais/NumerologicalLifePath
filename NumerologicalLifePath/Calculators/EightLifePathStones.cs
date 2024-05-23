using NumerologicalLifePath.Sdk.Abstractions;
using NumerologicalLifePath.Sdk.Commands.LifePath;
using NumerologicalLifePath.Sdk.CompoundCommands.LifePath;

namespace NumerologicalLifePath.Sdk.Calculators;

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
