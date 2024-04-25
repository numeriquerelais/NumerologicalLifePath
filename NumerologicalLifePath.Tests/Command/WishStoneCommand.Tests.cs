using NFluent;
using NumerologicalLifePath.Commands;

namespace NumerologicalLifePath.Tests.Command;

public sealed class WishStoneCommandTests
{
    [TestCase("Romain Pierre", "Michel Tiago", 33)]
    [TestCase("Diego Armando", "Maradona Franco", 12)]
    [TestCase("Diego Irmando", "Miradona Frinco", 9)]
    public void Should_Execute_Command(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new([.. firstNames.Split(" ")], [.. lastNames.Split(" ")], new DateOnly());
        var command = new WishStoneCommand(clt);
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command()
    {
        Client clt = new([.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")], new DateOnly());

        var command = new WishStoneCommand(clt);

        Check.ThatCode(() => command.Execute())
               .Throws<ArgumentException>()
               .WithMessage("No Vowel found.");
    }
}
