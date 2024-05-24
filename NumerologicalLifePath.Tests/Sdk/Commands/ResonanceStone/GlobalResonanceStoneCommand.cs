using NFluent;
using NumerologicalLifePath.Sdk;
using NumerologicalLifePath.Sdk.Commands.ResonanceStone;
using System.Globalization;

namespace NumerologicalLifePath.Tests.Sdk.Command.ResonanceStone;

public sealed class GlobalResonanceStoneCommandTests
{
    [TestCase("08/02/1968", 7)]
    [TestCase("20/04/1985", 11)]
    [TestCase("09/06/1996", 4)]
    [TestCase("10/09/1990", 11)]
    [TestCase("24/02/1978", 33)]
    [TestCase("29/04/2014", 22)]
    public void Should_Execute_Command(string strBirthDate, int expectedResult)
    {
        DateTime.TryParseExact(strBirthDate, "dd/MM/yyyy",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out var birthDate);
        Client clt = new(new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day));
        var command = new GlobalResonanceStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command_Without_BirthDate()
    {
        Client clt = new(string.Empty, string.Empty);
        var command = new GlobalResonanceStoneCommand() { Client = clt };

        Check.ThatCode(() => command.Execute())
               .Throws<InvalidOperationException>()
               .WithMessage("The birthdate is null.");
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new GlobalResonanceStoneCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<InvalidOperationException>()
               .WithMessage("Client is null.");
    }
}
