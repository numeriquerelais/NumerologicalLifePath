using NFluent;
using NumerologicalLifePath.Commands;
using System.Globalization;

namespace NumerologicalLifePath.Tests.Command;

public sealed class GlobalResonanceStoneCommandTests
{
    [TestCase("8/2/1968", 7)]
    [TestCase("20/4/1985", 11)]
    [TestCase("9/6/1996", 4)]
    [TestCase("10/9/1990", 11)]
    [TestCase("24/2/1978", 33)]
    [TestCase("29/4/2014", 22)]
    public void Should_Execute_Command(string strBirthDate, int expectedResult)
    {
        var birthDate = DateTime.Parse(strBirthDate, CultureInfo.CreateSpecificCulture("fr-FR"));
        Client clt = new([.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")], new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day));
        var command = new GlobalResonanceStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new GlobalResonanceStoneCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<NullReferenceException>()
               .WithMessage("Object reference not set to an instance of an object.");
    }
}
