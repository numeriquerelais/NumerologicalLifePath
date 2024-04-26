using NFluent;
using NumerologicalLifePath.Commands;

namespace NumerologicalLifePath.Tests.Command;

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
    [TestCase("9/05/1990", 9)]
    [TestCase("8/05/1990", 8)]
    [TestCase("7/05/1990", 7)]
    [TestCase("6/05/1990", 6)]
    [TestCase("5/05/1990", 5)]
    [TestCase("4/05/1990", 4)]
    [TestCase("3/05/1990", 3)]
    [TestCase("2/05/1990", 2)]
    [TestCase("1/05/1990", 1)]
    public void Should_Execute_Command(string strBirthDate, int expectedResult)
    {
        var birthDate = Convert.ToDateTime(strBirthDate).Date;
        Client clt = new([.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")], new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day));
        var command = new MoonResonanceStoneCommand(clt);
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }
}
