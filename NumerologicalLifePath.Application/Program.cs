using NumerologicalLifePath.Application;
using NumerologicalLifePath.Application.CliCommands;

var cli = new Cli([
    new BirthDateResonanceStonesCliCommand(),
    new EightLifePathStonesCliCommand(),
    new InclusionGridCliCommand()
    ]);
return await cli.StartAsync(args);
