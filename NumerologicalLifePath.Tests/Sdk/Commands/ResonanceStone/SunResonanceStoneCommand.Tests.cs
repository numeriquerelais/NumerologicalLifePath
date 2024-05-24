using NFluent;
using NumerologicalLifePath.Sdk;
using NumerologicalLifePath.Sdk.Commands.ResonanceStone;
using System.Globalization;

namespace NumerologicalLifePath.Tests.Sdk.Command.ResonanceStone;

public sealed class SunResonanceStoneCommandTests
{

    [TestCase("01/01/1990", 1)]
    [TestCase("01/02/1990", 2)]
    [TestCase("01/03/1990", 3)]
    [TestCase("01/04/1990", 4)]
    [TestCase("01/05/1990", 5)]
    [TestCase("01/06/1990", 6)]
    [TestCase("01/07/1990", 7)]
    [TestCase("01/08/1990", 8)]
    [TestCase("01/09/1990", 9)]
    [TestCase("01/10/1990", 1)]
    [TestCase("01/11/1990", 2)]
    [TestCase("01/12/1990", 3)]
    public void Should_Execute_Command(string strBirthDate, int expectedResult)
    {
        DateTime.TryParseExact(strBirthDate, "dd/MM/yyyy",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out var birthDate);
        Client clt = new(new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day), [.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")]);
        var command = new SunResonanceStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new SunResonanceStoneCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<InvalidOperationException>()
               .WithMessage("Client is null.");
    }
}
