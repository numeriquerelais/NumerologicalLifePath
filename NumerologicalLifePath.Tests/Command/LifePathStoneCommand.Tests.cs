using NFluent;
using NumerologicalLifePath.Commands;
using System.Globalization;

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
        DateTime.TryParseExact(strBirthDate, "dd/MM/yyyy",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out var birthDate);
        Client clt = new([.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")], new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day));
        var command = new LifePathStoneCommand() { Client = clt};
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new LifePathStoneCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<NullReferenceException>()
               .WithMessage("Object reference not set to an instance of an object.");
    }
}
