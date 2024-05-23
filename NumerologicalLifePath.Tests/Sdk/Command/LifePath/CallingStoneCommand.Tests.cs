using NFluent;
using NumerologicalLifePath.Sdk;
using NumerologicalLifePath.Sdk.Commands.LifePath;

namespace NumerologicalLifePath.Tests.Sdk.Command.LifePath;

public sealed class CallingStoneCommandTests
{
    [TestCase("Romain Pierre", "Michel Tiago", 11)]
    [TestCase("Diego Armando", "Maradona Franco", 8)]
    [TestCase("John", "Doe", 17)]
    [TestCase("Ma", "Pa", 2)]
    public void Should_Execute_Command(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new(new DateOnly(), [.. firstNames.Split(" ")], [.. lastNames.Split(" ")]);
        var command = new CallingStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [TestCase("Romain Pierre", "Michel Tiago", 65)]
    [TestCase("Diego Armando", "Maradona Franco", 44)]
    [TestCase("John", "Doe", 17)]
    public void Should_Execute_Command_With_Not_Reduced_Result(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new(new DateOnly(), [.. firstNames.Split(" ")], [.. lastNames.Split(" ")]);
        var command = new CallingStoneCommand(false) { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command()
    {
        Client clt = new(new DateOnly());

        var command = new CallingStoneCommand() { Client = clt };

        Check.ThatCode(() => command.Execute())
               .Throws<ArgumentException>()
               .WithMessage("No vowel found.");
    }

    [Test]
    public void Should_Not_Execute_Command_Without_FirstName_And_LastName()
    {
        Client clt = new(new DateOnly());

        var command = new CallingStoneCommand() { Client = clt };

        Check.ThatCode(() => command.Execute())
               .Throws<ArgumentException>()
               .WithMessage("No vowel found.");
    }

    [Test]
    public void Should_Not_Execute_Command_WithoutClient()
    {
        var command = new CallingStoneCommand();

        Check.ThatCode(() => { command.Execute(); })
            .Throws<InvalidOperationException>()
            .WithMessage("Client is null.");
    }
}
