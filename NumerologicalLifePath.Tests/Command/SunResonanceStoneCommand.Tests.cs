﻿using NFluent;
using NumerologicalLifePath.Commands;
using System.Globalization;

namespace NumerologicalLifePath.Tests.Command;

public sealed class SunResonanceStoneCommandTests
{
    
    [TestCase("1/01/1990", 1)]
    [TestCase("1/02/1990", 2)]
    [TestCase("1/03/1990", 3)]
    [TestCase("1/04/1990", 4)]
    [TestCase("1/05/1990", 5)]
    [TestCase("1/06/1990", 6)]
    [TestCase("1/07/1990", 7)]
    [TestCase("1/08/1990", 8)]
    [TestCase("1/09/1990", 9)]
    [TestCase("1/10/1990", 1)]
    [TestCase("1/11/1990", 2)]
    [TestCase("1/12/1990", 3)]
    public void Should_Execute_Command(string strBirthDate, int expectedResult)
    {
        var birthDate = DateTime.Parse(strBirthDate, CultureInfo.CreateSpecificCulture("fr-FR"));
        Client clt = new([.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")], new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day));
        var command = new SunResonanceStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new SunResonanceStoneCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<NullReferenceException>()
               .WithMessage("Object reference not set to an instance of an object.");
    }
}
