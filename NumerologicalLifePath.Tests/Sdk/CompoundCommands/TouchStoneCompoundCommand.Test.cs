﻿using NFluent;
using NumerologicalLifePath.CompoundCommands;

namespace NumerologicalLifePath.Sdk.CompoundCommands.Tests;

public sealed class TouchStoneCompoundCommandTests
{
    [TestCase("Romain Pierre", "Michel Tiago", 5)]
    [TestCase("Diego Armando", "Maradona Franco", 17)]
    public void Should_Execute_Commands(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new(new DateOnly(), [.. firstNames.Split(" ")], [.. lastNames.Split(" ")]);
        var command = new TouchStoneCompoundCommand();
        command.SetClient(clt);
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [TestCase("Romain Pierre", "Michel Tiago", 311)]
    [TestCase("Diego Armando", "Maradona Franco", 278)]
    public void Should_Execute__Not_Reduced_Commands(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new(new DateOnly(), [.. firstNames.Split(" ")], [.. lastNames.Split(" ")]);
        var command = new TouchStoneCompoundCommand(false);
        command.SetClient(clt);

        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Commands()
    {
        Client clt = new(new DateOnly(), [.. string.Empty.Split(" ")], [.. string.Empty.Split(" ")]);

        var command = new ExpressionStoneCompoundCommand();
        command.SetClient(clt);

        Check.ThatCode(() => command.Execute())
               .Throws<Exception>();
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new ExpressionStoneCompoundCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<InvalidOperationException>()
               .WithMessage("Client is null.");
    }
}
