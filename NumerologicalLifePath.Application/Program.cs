using NumerologicalLifePath.Application;
using NumerologicalLifePath.Application.CliCommands;

// Root
var cli = new Cli([
    new BirthDateResonanceStonesCliCommand(),
    new EightLifePathStonesCliCommand()
    ]);
return await cli.StartAsync(args);
