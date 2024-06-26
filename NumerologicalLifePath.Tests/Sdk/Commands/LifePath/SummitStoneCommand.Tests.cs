﻿using NFluent;
using NumerologicalLifePath.Sdk;
using NumerologicalLifePath.Sdk.Commands.LifePath;

namespace NumerologicalLifePath.Tests.Sdk.Command.LifePath;

public sealed class SummitStoneCommandTests
{
    [TestCase("Romain Pierre", "Michel Tiago", 19)]
    [TestCase("Diego Armando", "Maradona Franco", 19)]
    [TestCase("Edson", "Arantes do Nascimento", 18)]
    [TestCase("Neymar Júnior", "da Silva Santos", 21)]
    [TestCase("Cristiano Ronaldo", "dos Santos Aveiro", 20)]
    [TestCase("Ryar Ronaldor", "Roanitor Riberryr", 9)]
    [TestCase("John", "Doe", 10)]
    public void Should_Execute_Command(string firstNames, string lastNames, int expectedResult)
    {
        Client clt = new(firstNames, lastNames);
        var command = new SummitStoneCommand() { Client = clt };
        command.Execute();
        Check.That(command.Result).Equals(expectedResult);
    }

    [Test]
    public void Should_Not_Execute_Command()
    {
        Client clt = new(string.Empty, string.Empty);

        var command = new SummitStoneCommand() { Client = clt };

        Check.ThatCode(() => command.Execute())
               .Throws<ArgumentException>()
               .WithMessage("Client first names and/or last names lists are empties.");
    }

    [Test]
    public void Should_Not_Execute_Command_Without_Client()
    {
        var command = new SummitStoneCommand();

        Check.ThatCode(() => command.Execute())
               .Throws<InvalidOperationException>()
               .WithMessage("Client is null.");
    }
}
