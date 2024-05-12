using System.CommandLine;
using NumerologicalLifePath.Application.CliCommands.Commands;
using NumerologicalLifePath.Application.CliCommands.Interfaces;

namespace NumerologicalLifePath.Application.CliCommands.Wrappers;

public class ThreeOptionsCliCommandWrapper<T1, T2, T3>(ThreeOptionsCliCommand<T1, T2, T3> cliCommand) : ICliCommand, ICliCommandThreeParams<T1, T2, T3>
{
    protected readonly ThreeOptionsCliCommand<T1, T2, T3> _cliCommand = cliCommand;

    public Action<T1, T2, T3> Handle => _cliCommand.Handle;

    public Option<T1> Option1 => _cliCommand.Option1;
    public Option<T2> Option2 => _cliCommand.Option2;
    public Option<T3> Option3 => _cliCommand.Option3;

    public string CommandName => _cliCommand.CommandName;

    public string Description => _cliCommand.Description;
}