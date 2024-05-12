using NumerologicalLifePath.Calculators;

namespace NumerologicalLifePath.Sdk.Calculators.Tests;
using NFluent;

public sealed class BirthDateResonanceStonesTests
{

    [TestCase(2014, 4, 29, 2, 4, 7, 22)]
    [TestCase(2011, 2, 14, 5, 2, 4, 11)]
    [TestCase(1978, 2, 24, 6, 2, 7, 33)]
    [TestCase(1996, 6, 9, 9, 6, 7, 4)]
    [TestCase(1968, 2, 8, 8, 2, 6, 7)]
    [TestCase(1890, 11, 22, 4, 2, 9, 6)]
    [TestCase(1968, 3, 1, 1, 3, 6, 1)]
    public void Should_Calculate_Resonances_Stones_Values(int year, int month, int day, int expectedMoonResult, int expectedSunResult, int expectedEarthResult, int expectedGlobalResult)
    {
        var calculator = new BirthDateResonanceStones();
        var results = calculator.Calculate(new DateOnly(year, month, day));

        Dictionary<string, short> expectedResults = new()
        {
            {"MoonResonanceStone", (short)expectedMoonResult },
            {"SunResonanceStone", (short)expectedSunResult },
            {"EarthResonanceStone", (short)expectedEarthResult },
            {"GlobalResonanceStone", (short)expectedGlobalResult },
        };

        Check.That(results).Contains(expectedResults);
    }

    [TestCase(2014, 4, 29, "Red Jasper", "Jade", "Citrine", "Rock Crystal")]
    [TestCase(2011, 2, 14, "Emerald", "Red Jasper", "Jade", "Carnelian")]
    [TestCase(1978, 2, 24, "Garnet", "Red Jasper", "Citrine", "Tourmalinated Quartz")]
    [TestCase(1996, 6, 9, "Aquamarine", "Garnet", "Citrine", "Jade")]
    [TestCase(1968, 2, 8, "Obsidian", "Red Jasper", "Garnet", "Citrine")]
    [TestCase(1890, 11, 22, "Jade", "Red Jasper", "Aquamarine", "Garnet")]
    [TestCase(1968, 3, 1, "Pink Quartz", "Chalcedony", "Garnet", "Pink Quartz")]
    public void Should_Calculate_Resonances_Stones(int year, int month, int day, string expectedMoonResult, string expectedSunResult, string expectedEarthResult, string expectedGlobalResult)
    {
        var calculator = new BirthDateResonanceStones();
        var results = calculator.CalculateStones(new DateOnly(year, month, day));

        Dictionary<string, string> expectedResults = new()
        {
            {"MoonResonanceStone", expectedMoonResult },
            {"SunResonanceStone", expectedSunResult },
            {"EarthResonanceStone", expectedEarthResult },
            {"GlobalResonanceStone", expectedGlobalResult },
        };

        Check.That(results).Contains(expectedResults);
    }
}
