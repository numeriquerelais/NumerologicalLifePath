using NFluent;
using NumerologicalLifePath.Sdk;
using NumerologicalLifePath.Sdk.Commands.InclusionGrid;

namespace NumerologicalLifePath.Tests.Sdk.Commands.InclusionGrid;

public sealed class InclusionGridStoneCommandTests
{
    private static readonly object[] clients =
    {
        new object[] { "Diego Armando", "Maradona Franco", new short[] { 6,0,1,5,4,5,1,0,4 } },
        new object[] { "Jean", "Chartrain", new short[] { 4,1,1,0,3,0,0,1,3 } },
    };

    [TestCaseSource(nameof(clients))]
    public void Should_Execute_Command(string firstNames, string lastNames, short[] expectedResult)
    {
        Client clt = new(firstNames, lastNames);
        var command = new InclusionGridCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command_Without_FirstName_And_LastName()
    {
        Client clt = new(new DateOnly());

        var command = new InclusionGridCommand() { Client = clt };

        Check.ThatCode(() => command.Execute())
               .Throws<ArgumentException>()
               .WithMessage("Client first names and/or last names lists are empties.");
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new InclusionGridCommand();

        Check.ThatCode(() => { command.Execute(); })
            .Throws<InvalidOperationException>()
            .WithMessage("Client is null.");
    }
}