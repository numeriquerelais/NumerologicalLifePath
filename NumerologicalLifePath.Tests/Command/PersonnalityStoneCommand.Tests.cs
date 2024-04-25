﻿using NFluent;
using NumerologicalLifePath.Commands;

namespace NumerologicalLifePath.Tests.Command;

public sealed class PersonnalityStoneCommandTests
{
    [TestCase("Romain Pierre", "Michel Tiago", 7)]
    [TestCase("Diego Armando", "Maradona Franco", 15)]
    [TestCase("Joe", "Soe", 2)]
    public void Should_Execute_Command(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new([.. firstNames.Split(" ")], [.. lastNames.Split(" ")], new DateOnly());
        var command = new PersonnalityStoneCommand(clt);
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [TestCase("Romain Pierre", "Michel Tiago", 70)]
    [TestCase("Diego Armando", "Maradona Franco", 78)]
    public void Should_Execute_Command_With_Not_Reduced_Result(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new([.. firstNames.Split(" ")], [.. lastNames.Split(" ")], new DateOnly());
        var command = new PersonnalityStoneCommand(clt, false);
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }


    [Test]
    public void Should_Not_Execute_Command()
    {
        Client clt = new([.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")], new DateOnly());

        var command = new PersonnalityStoneCommand(clt);

        Check.ThatCode(() => command.Execute())
               .Throws<ArgumentException>()
               .WithMessage("No consonant found.");
    }
}