using NumerologicalLifePath.Commands;

namespace NumerologicalLifePath.Calculators;

public sealed class BirthDateResonanceStones : ACalculator
{
    public BirthDateResonanceStones() :
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
