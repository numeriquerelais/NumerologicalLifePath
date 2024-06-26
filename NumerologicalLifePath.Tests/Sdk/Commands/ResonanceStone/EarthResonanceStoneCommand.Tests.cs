﻿using NFluent;
using NumerologicalLifePath.Sdk;
using NumerologicalLifePath.Sdk.Commands.LifePath;
using NumerologicalLifePath.Sdk.Commands.ResonanceStone;
using System.Globalization;

namespace NumerologicalLifePath.Tests.Sdk.Command.ResonanceStone;

public sealed class EarthResonanceStoneCommandTests
{
    [TestCase("01/01/1999", 1)]
    [TestCase("01/01/2000", 2)]
    [TestCase("01/01/2001", 3)]
    [TestCase("01/01/2002", 4)]
    [TestCase("01/01/2003", 5)]
    [TestCase("01/01/2004", 6)]
    [TestCase("01/01/2005", 7)]
    [TestCase("01/01/2006", 8)]
    [TestCase("01/01/2007", 9)]
    [TestCase("01/01/2008", 1)]
    public void Should_Execute_Command(string strBirthDate, int expectedResult)
    {
        DateTime.TryParseExact(strBirthDate, "dd/MM/yyyy",
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out var birthDate);
        Client clt = new(new DateOnly(birthDate.Year, birthDate.Month, birthDate.Day));
        var command = new EarthResonanceStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command_Without_BirthDate()
    {
        Client clt = new(string.Empty, string.Empty);
        var command = new EarthResonanceStoneCommand() { Client = clt };

        Check.ThatCode(() => command.Execute())
               .Throws<InvalidOperationException>()
               .WithMessage("The birthdate is null.");
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new EarthResonanceStoneCommand();

        Check.ThatCode(() => { command.Execute(); })
            .Throws<InvalidOperationException>()
            .WithMessage("Client is null.");
    }
}
