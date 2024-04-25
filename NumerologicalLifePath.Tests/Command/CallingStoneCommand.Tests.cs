﻿using NFluent;
using NumerologicalLifePath.Commands;

namespace NumerologicalLifePath.Tests.Command;

public sealed class CallingStoneCommandTests
{
    [TestCase("Romain Pierre", "Michel Tiago", 11)]
    [TestCase("Diego Armando", "Maradona Franco", 8)]
    [TestCase("John", "Doe", 17)]
    [TestCase("Ma", "Pa", 2)]
    public void Should_Execute_Command(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new([.. firstNames.Split(" ")], [.. lastNames.Split(" ")], new DateOnly());
        var command = new CallingStoneCommand(clt);
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [TestCase("Romain Pierre", "Michel Tiago", 65)]
    [TestCase("Diego Armando", "Maradona Franco", 44)]
    [TestCase("John", "Doe", 17)]
    public void Should_Execute_Command_With_Not_Reduced_Result(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new([.. firstNames.Split(" ")], [.. lastNames.Split(" ")], new DateOnly());
        var command = new CallingStoneCommand(clt, false);
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command()
    {
        Client clt = new([.. string.Empty.Split("")], [.. string.Empty.Split("")], new DateOnly());

        var command = new CallingStoneCommand(clt);

        Check.ThatCode(() => command.Execute())
               .Throws<ArgumentException>()
               .WithMessage("No Vowel found.");
    }
}
