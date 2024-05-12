using System.CommandLine;
using NumerologicalLifePath.Application.CliCommands.Commands;
using NumerologicalLifePath.Application.CliCommands.Interfaces;

namespace NumerologicalLifePath.Application.CliCommands.Wrappers;

public class SingleCliCommandWrapper<T>(SingleOptionCliCommand<T> cliCommand) : ICliCommand, ICliCommandParams<T>
{
    protected readonly SingleOptionCliCommand<T> _cliCommand = cliCommand;

    public Action<T> Handle => _cliCommand.Handle;

    public Option<T> Option => _cliCommand.Option;

    public string CommandName => _cliCommand.CommandName;

    public string Description => _cliCommand.Description;
}