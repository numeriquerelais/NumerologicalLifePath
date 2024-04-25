using NFluent;
using NumerologicalLifePath.CompoundCommands;

namespace NumerologicalLifePath.Tests.CompoundCommands;

public sealed class TouchStoneCompoundCommandTests
{
    [TestCase("Romain Pierre", "Michel Tiago", 5)]
    [TestCase("Diego Armando", "Maradona Franco", 17)]
    public void Should_Execute_Commands(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new([.. firstNames.Split(" ")], [.. lastNames.Split(" ")], new DateOnly());
        var command = new TouchStoneCompoundCommand(clt);
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [TestCase("Romain Pierre", "Michel Tiago", 311)]
    [TestCase("Diego Armando", "Maradona Franco", 278)]
    public void Should_Execute__Not_Reduced_Commands(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new([.. firstNames.Split(" ")], [.. lastNames.Split(" ")], new DateOnly());
        var command = new TouchStoneCompoundCommand(clt, false);
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Commands()
    {
        Client clt = new([.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")], new DateOnly());

        var command = new ExpressionStoneCompoundCommand(clt);

        Check.ThatCode(() => command.Execute())
               .Throws<Exception>();
    }
}
