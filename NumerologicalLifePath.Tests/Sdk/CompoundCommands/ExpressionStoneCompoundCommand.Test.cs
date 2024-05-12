using NFluent;
using NumerologicalLifePath.CompoundCommands;

namespace NumerologicalLifePath.Sdk.CompoundCommands.Tests;

public sealed class ExpressionStoneCompoundCommandTests
{
    [TestCase("Romain Pierre", "Michel Tiago", 9)]
    [TestCase("Diego Armando", "Maradona Franco", 5)]
    public void Should_Execute_Commands(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new([.. firstNames.Split(" ")], [.. lastNames.Split(" ")], new DateOnly());
        var command = new ExpressionStoneCompoundCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }


    [TestCase("Romain Pierre", "Michel Tiago", 135)]
    [TestCase("Diego Armando", "Maradona Franco", 122)]
    public void Should_Execute_Commands_Not_Reduced(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new([.. firstNames.Split(" ")], [.. lastNames.Split(" ")], new DateOnly());
        var command = new ExpressionStoneCompoundCommand(false) { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Commands()
    {
        Client clt = new([.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")], new DateOnly());

        var command = new ExpressionStoneCompoundCommand() { Client = clt };

        Check.ThatCode(() => command.Execute())
               .Throws<Exception>();
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new ExpressionStoneCompoundCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<NullReferenceException>()
               .WithMessage("Object reference not set to an instance of an object.");
    }
}
