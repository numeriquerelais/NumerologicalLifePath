using NFluent;
using NumerologicalLifePath.Sdk;
using NumerologicalLifePath.Sdk.CompoundCommands.LifePath;

namespace NumerologicalLifePath.Tests.Sdk.Command.LifePath.CompoundCommands;

public sealed class ExpressionStoneCompoundCommandTests
{
    [TestCase("Romain Pierre", "Michel Tiago", 9)]
    [TestCase("Diego Armando", "Maradona Franco", 5)]
    public void Should_Execute_Commands(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new(new DateOnly(), [.. firstNames.Split(" ")], [.. lastNames.Split(" ")]);
        var command = new ExpressionStoneCompoundCommand();
        command.SetClient(clt);
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }


    [TestCase("Romain Pierre", "Michel Tiago", 135)]
    [TestCase("Diego Armando", "Maradona Franco", 122)]
    public void Should_Execute_Commands_Not_Reduced(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new(new DateOnly(), [.. firstNames.Split(" ")], [.. lastNames.Split(" ")]);
        var command = new ExpressionStoneCompoundCommand(false);
        command.SetClient(clt);
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Commands()
    {
        Client clt = new(new DateOnly(), [.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")]);

        var command = new ExpressionStoneCompoundCommand();
        command.SetClient(clt);

        Check.ThatCode(() => command.Execute())
               .Throws<Exception>();
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new ExpressionStoneCompoundCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<InvalidOperationException>()
               .WithMessage("Client is null.");
    }
}
