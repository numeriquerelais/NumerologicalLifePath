using NFluent;
using NumerologicalLifePath.Sdk;
using NumerologicalLifePath.Sdk.Calculators;

namespace NumerologicalLifePath.Tests.Sdk.Calculators;

public sealed class EightLifePathStonesTests
{

    [TestCase("Charles André Joseph Marie", "de Gaulle Maillot", 1890, 11, 22, 24, 31, 15, 14, 2, 16, 15, 16)]
    [TestCase("Emmanuel Jean-Michel Frédéric", "Macron Noguès", 1977, 12, 21, 21, 15, 3, 11, 6, 17, 16, 22)]
    public void Should_Calculate_Resonances_Stones_Values(
        string firstNames, string lastNames, int year, int month, int day,
        int expectedFoundationStone,
        int expectedSummitStone,
        int expectedLifePathStone,
        int expectedCallingStone,
        int expectedPersonnalityStone,
        int expectedExpressionStone,
        int expectedTouchStone,
        int expectedWishStone)
    {
        var calculator = new EightLifePathStones();
        var results = calculator.Calculate(new Client(new DateOnly(year, month, day), firstNames, lastNames));

        Dictionary<string, short> expectedResults = new()
    {
        {"FoundationStone", (short)expectedFoundationStone },
        {"SummitStone", (short)expectedSummitStone },
        {"LifePathStone", (short)expectedLifePathStone },
        {"CallingStone", (short)expectedCallingStone },
        {"PersonnalityStone", (short)expectedPersonnalityStone },
        {"ExpressionStone", (short)expectedExpressionStone },
        {"TouchStone", (short)expectedTouchStone },
        {"WishStone", (short)expectedWishStone },
    };

        Check.That(results).Contains(expectedResults);
    }

    [TestCase("Charles André Joseph Marie", "de Gaulle Maillot", 1890, 11, 22, "Amazonite", "Moonstone", "Malachite", "Amethyst", "Red Jasper", "Opal", "Malachite", "Opal")]
    [TestCase("Emmanuel Jean-Michel Frédéric", "Macron Noguès", 1977, 12, 21, "Tourmaline", "Malachite", "Chalcedony", "Carnelian", "Garnet", "Turquoise", "Opal", "Rock Crystal")]
    public void Should_Calculate_Resonances_Stones(
        string firstNames, string lastNames, int year, int month, int day,
        string expectedFoundationStone,
        string expectedSummitStone,
        string expectedLifePathStone,
        string expectedCallingStone,
        string expectedPersonnalityStone,
        string expectedExpressionStone,
        string expectedTouchStone,
        string expectedWishStone)
    {
        var calculator = new EightLifePathStones();
        var results = calculator.CalculateStones(new Client(new DateOnly(year, month, day), firstNames, lastNames));

        Dictionary<string, string> expectedResults = new()
    {
        {"FoundationStone", expectedFoundationStone },
        {"SummitStone", expectedSummitStone },
        {"LifePathStone", expectedLifePathStone },
        {"CallingStone", expectedCallingStone },
        {"PersonnalityStone", expectedPersonnalityStone },
        {"ExpressionStone", expectedExpressionStone },
        {"TouchStone", expectedTouchStone },
        {"WishStone", expectedWishStone },
    };

        Check.That(results).Contains(expectedResults);
    }
}
