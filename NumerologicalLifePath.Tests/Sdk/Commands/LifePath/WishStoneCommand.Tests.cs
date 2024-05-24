using NFluent;
using NumerologicalLifePath.Sdk;
using NumerologicalLifePath.Sdk.Commands.LifePath;

namespace NumerologicalLifePath.Tests.Sdk.Command.LifePath;

public sealed class WishStoneCommandTests
{
    [TestCase("Romain Pierre", "Michel Tiago", 33)]
    [TestCase("Diego Armando", "Maradona Franco", 12)]
    [TestCase("Diego Irmando", "Miradona Frinco", 9)]
    public void Should_Execute_Command(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new(firstNames, lastNames);
        var command = new WishStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command()
    {
        Client clt = new(string.Empty, string.Empty);

        var command = new WishStoneCommand() { Client = clt };

        Check.ThatCode(() => command.Execute())
               .Throws<ArgumentException>()
               .WithMessage("No vowel found.");
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new WishStoneCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<InvalidOperationException>()
               .WithMessage("Client is null.");
    }
}
