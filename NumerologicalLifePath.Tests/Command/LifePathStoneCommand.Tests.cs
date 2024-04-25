using NFluent;
using NumerologicalLifePath.Commands;

namespace NumerologicalLifePath.Tests.Command;

public sealed class LifePathStoneCommandTests
{
    [TestCase("31/05/1990", 10)]
    [TestCase("30/10/1960", 2)]
    [TestCase("05/02/1985", 21)]
    [TestCase("01/01/0032", 7)]
    [TestCase("29/12/9937", 33)]
    [TestCase("29/12/9938", 7)]
    public void Should_Execute_Command(string strBirthDate, int expectedResult)
    {
        var birthDate = Convert.ToDateTime(strBirthDate).Date;
        Client clt = new([.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")], new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day));
        var command = new LifePathStoneCommand(clt);
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }
}
