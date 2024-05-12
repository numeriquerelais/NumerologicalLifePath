using NumerologicalLifePath.Application.CliCommands;
using NumerologicalLifePath.Application.CliCommands.Interfaces;
using NumerologicalLifePath.Application.CliCommands.Wrappers;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

namespace NumerologicalLifePath.Application;

public class Cli
{
    private readonly RootCommand RootCommand = new("Numelorogical application");

    public Cli(List<ICliCommand> cmds) {
        foreach (var cmd in cmds)
        {

            if (cmd is BirthDateResonanceStonesCliCommand birth) 
            { 
                AddCommand(birth);
                continue;
            }

            if (cmd is EightLifePathStonesCliCommand lifePath)
            {
                AddCommand(lifePath);
                continue;
            }

            throw new ArgumentException($"Not supported command type {cmd.GetType().Name}.");
        }
    }

    public Task<int> StartAsync(string[] args) {       
        var commandLineBuilder = new CommandLineBuilder(RootCommand);

        commandLineBuilder.AddMiddleware(async (context, next) =>
        {
            await next(context);
        });

        commandLineBuilder.UseDefaults();
        Parser parser = commandLineBuilder.Build();

        return parser.InvokeAsync(args);
    }

    private void AddCommand<T>(SingleCliCommandWrapper<T> wrapper) {
        var cmd = new Command(wrapper.CommandName, wrapper.Description);
        cmd.AddOption(wrapper.Option);

        RootCommand.AddCommand(cmd);
        cmd.SetHandler(
            (info) => wrapper.Handle(info!),
            wrapper.Option
        );

    }

    private void AddCommand<T1, T2, T3>(ThreeOptionsCliCommandWrapper<T1, T2, T3> wrapper)
    {
        var cmd = new Command(wrapper.CommandName, wrapper.CommandName);
        cmd.AddOption(wrapper.Option1);
        cmd.AddOption(wrapper.Option2);
        cmd.AddOption(wrapper.Option3);

        RootCommand.AddCommand(cmd);
        cmd.SetHandler(
            (arg1, arg2, arg3) => wrapper.Handle(arg1!, arg2!, arg3!),
            wrapper.Option1, wrapper.Option2, wrapper.Option3
        );
    }
}
