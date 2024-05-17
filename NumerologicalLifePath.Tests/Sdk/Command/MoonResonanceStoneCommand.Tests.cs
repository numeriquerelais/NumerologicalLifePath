using NFluent;
using NumerologicalLifePath.Commands;
using System.Globalization;

namespace NumerologicalLifePath.Sdk.Command.Tests;

public sealed class MoonResonanceStoneCommandTests
{
    [TestCase("31/05/1990", 4)]
    [TestCase("30/05/1990", 3)]
    [TestCase("29/05/1990", 2)]
    [TestCase("28/05/1990", 1)]
    [TestCase("27/05/1990", 9)]
    [TestCase("26/05/1990", 8)]
    [TestCase("25/05/1990", 7)]
    [TestCase("24/05/1990", 6)]
    [TestCase("23/05/1990", 5)]
    [TestCase("22/05/1990", 4)]
    [TestCase("21/05/1990", 3)]
    [TestCase("20/05/1990", 2)]
    [TestCase("19/05/1990", 1)]
    [TestCase("18/05/1990", 9)]
    [TestCase("17/05/1990", 8)]
    [TestCase("16/05/1990", 7)]
    [TestCase("15/05/1990", 6)]
    [TestCase("14/05/1990", 5)]
    [TestCase("13/05/1990", 4)]
    [TestCase("12/05/1990", 3)]
    [TestCase("11/05/1990", 2)]
    [TestCase("10/05/1990", 1)]
    [TestCase("09/05/1990", 9)]
    [TestCase("08/05/1990", 8)]
    [TestCase("07/05/1990", 7)]
    [TestCase("06/05/1990", 6)]
    [TestCase("05/05/1990", 5)]
    [TestCase("04/05/1990", 4)]
    [TestCase("03/05/1990", 3)]
    [TestCase("02/05/1990", 2)]
    [TestCase("01/05/1990", 1)]
    public void Should_Execute_Command(string strBirthDate, int expectedResult)
    {
        DateTime.TryParseExact(strBirthDate, "dd/MM/yyyy",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out var birthDate);
        Client clt = new(new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day), [.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")]);
        var command = new MoonResonanceStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new MoonResonanceStoneCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<InvalidOperationException>()
               .WithMessage("Client is null.");
    }
}
