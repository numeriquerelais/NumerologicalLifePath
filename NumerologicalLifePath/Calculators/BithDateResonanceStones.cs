using NumerologicalLifePath.Commands;

namespace NumerologicalLifePath.Calculators;

public sealed class BithDateResonanceStones : ACalculator
{
    public BithDateResonanceStones() :
        base(new Calculator([
            new GlobalResonanceStoneCommand(),
            new MoonResonanceStoneCommand(),
            new SunResonanceStoneCommand(),
            new EarthResonanceStoneCommand()
        ]))
    { }

    public Dictionary<string, Int16> Calculate(DateOnly birthdate)
    {
        return Calculate(new Client(
            [.. string.Empty.Split("")],
            [.. string.Empty.Split("")],
            birthdate));
    }

    public Dictionary<string, string> CalculateStones(DateOnly birthdate)
    {
        return CalculateStones(new Client(
            [.. string.Empty.Split("")],
            [.. string.Empty.Split("")],
            birthdate));
    }
}
