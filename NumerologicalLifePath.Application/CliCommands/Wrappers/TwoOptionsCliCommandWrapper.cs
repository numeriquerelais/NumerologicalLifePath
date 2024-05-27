using System.CommandLine;
using NumerologicalLifePath.Application.CliCommands.Commands;
using NumerologicalLifePath.Application.CliCommands.Interfaces;

namespace NumerologicalLifePath.Application.CliCommands.Wrappers;

public class TwoOptionsCliCommandWrapper<T1, T2>(TwoOptionsCliCommand<T1, T2> cliCommand) : ICliCommand, ICliCommandTwoParams<T1, T2>
{
    protected readonly TwoOptionsCliCommand<T1, T2> _cliCommand = cliCommand;

    public Action<T1, T2> Handle => _cliCommand.Handle;

    public Option<T1> Option1 => _cliCommand.Option1;
    public Option<T2> Option2 => _cliCommand.Option2;

    public string CommandName => _cliCommand.CommandName;

    public string Description => _cliCommand.Description;
}