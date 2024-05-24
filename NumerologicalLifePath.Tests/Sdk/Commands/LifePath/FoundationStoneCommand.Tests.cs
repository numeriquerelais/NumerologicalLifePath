using NFluent;
using NumerologicalLifePath.Sdk;
using NumerologicalLifePath.Sdk.Commands.LifePath;

namespace NumerologicalLifePath.Tests.Sdk.Command.LifePath;

public sealed class FoundationStoneCommandTests
{
    [TestCase("Romain Pierre", "Michel Tiago", 22)]
    [TestCase("Diego Armando", "Maradona Franco", 15)]
    [TestCase("Edson", "Arantes do Nascimento", 15)]
    [TestCase("Neymar Júnior", "da Silva Santos", 12)]
    [TestCase("Cristiano Ronaldo", "dos Santos Aveiro", 18)]
    [TestCase("Ryan Ronaldo", "Roanito Riberry", 9)]
    [TestCase("John", "Doe", 5)]
    public void Should_Execute_Command(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new(firstNames, lastNames);
        var command = new FoundationStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command()
    {
        Client clt = new(string.Empty, string.Empty);

        var command = new FoundationStoneCommand() { Client = clt };

        Check.ThatCode(() => command.Execute())
               .Throws<ArgumentException>()
               .WithMessage("Client first names and/or last names lists are empties.");
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new FoundationStoneCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<InvalidOperationException>()
               .WithMessage("Client is null.");
    }
}
