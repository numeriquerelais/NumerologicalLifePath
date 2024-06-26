﻿using NFluent;
using NumerologicalLifePath.Application.CliCommands;

namespace NumerologicalLifePath.Tests.Application;

public sealed class EightLifePathStonesCliCommandTests
{
    [Test]
    public void Construct_A_Not_Null_CliCommand()
    {
        var fileInfoCmd = new EightLifePathStonesCliCommand();
        Check.That(fileInfoCmd).IsNotNull().And.IsInstanceOf<EightLifePathStonesCliCommand>();
    }
}
