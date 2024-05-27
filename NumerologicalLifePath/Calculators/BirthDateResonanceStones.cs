using NumerologicalLifePath.Sdk.Abstractions;
using NumerologicalLifePath.Sdk.Commands.ResonanceStone;

namespace NumerologicalLifePath.Sdk.Calculators;

public sealed class BirthDateResonanceStones : ACalculator
{
    public BirthDateResonanceStones() :
        base(new ShortsCalculator([
            new GlobalResonanceStoneCommand(),
            new MoonResonanceStoneCommand(),
            new SunResonanceStoneCommand(),
            new EarthResonanceStoneCommand()
        ]))
    { }

    public Dictionary<string, short> Calculate(DateOnly birthdate)
    {
        return Calculate(new Client(birthdate));
    }

    public Dictionary<string, string> CalculateStones(DateOnly birthdate)
    {
        return CalculateStones(new Client(birthdate));
    }
}
