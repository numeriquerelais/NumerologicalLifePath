using NFluent;
using NumerologicalLifePath.Commands;
using System.Globalization;

namespace NumerologicalLifePath.Tests.Command;

public sealed class EarthResonanceStoneCommandTests
{
    [TestCase("1/1/1999", 1)]
    [TestCase("1/1/2000", 2)]
    [TestCase("1/1/2001", 3)]
    [TestCase("1/1/2002", 4)]
    [TestCase("1/1/2003", 5)]
    [TestCase("1/1/2004", 6)]
    [TestCase("1/1/2005", 7)]
    [TestCase("1/1/2006", 8)]
    [TestCase("1/1/2007", 9)]
    [TestCase("1/1/2008", 1)]
    public void Should_Execute_Command(string strBirthDate, int expectedResult)
    {
        var birthDate = DateTime.Parse(strBirthDate, CultureInfo.CreateSpecificCulture("fr-FR"));
        Client clt = new([.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")], new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day));
        var command = new EarthResonanceStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }
}
