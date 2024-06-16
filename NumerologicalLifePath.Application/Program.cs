using NumerologicalLifePath.Application;
using NumerologicalLifePath.Application.CliCommands;

Console.Write("Added to launch WF");

var cli = new Cli([
    new BirthDateResonanceStonesCliCommand(),
    new EightLifePathStonesCliCommand(),
    new InclusionGridCliCommand()
    ]);
return await cli.StartAsync(args);
