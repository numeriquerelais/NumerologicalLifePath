﻿using NFluent;
using NumerologicalLifePath.Commands;
using System.Globalization;

namespace NumerologicalLifePath.Sdk.Command.Tests;

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
        Client clt = new(new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day), [.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")]);
        var command = new LifePathStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new LifePathStoneCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<InvalidOperationException>()
               .WithMessage("Client is null.");
    }
}
