using NFluent;
using NumerologicalLifePath.Commands;

namespace NumerologicalLifePath.Sdk.Command.Tests;

public sealed class WishStoneCommandTests
{
    [TestCase("Romain Pierre", "Michel Tiago", 33)]
    [TestCase("Diego Armando", "Maradona Franco", 12)]
    [TestCase("Diego Irmando", "Miradona Frinco", 9)]
    public void Should_Execute_Command(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new([.. firstNames.Split(" ")], [.. lastNames.Split(" ")], new DateOnly());
        var command = new WishStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command()
    {
        Client clt = new([.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")], new DateOnly());

        var command = new WishStoneCommand() { Client = clt };

        Check.ThatCode(() => command.Execute())
               .Throws<ArgumentException>()
               .WithMessage("No Vowel found.");
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new WishStoneCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<NullReferenceException>()
               .WithMessage("Object reference not set to an instance of an object.");
    }
}
