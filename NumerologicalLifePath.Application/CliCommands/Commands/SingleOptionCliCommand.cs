using System.CommandLine;

namespace NumerologicalLifePath.Application.CliCommands.Commands;

public sealed class SingleOptionCliCommand<T>
{
    public readonly string CommandName;
    public readonly string Description;
    public readonly Action<T> Handle;
    public readonly Option<T> Option;

    public SingleOptionCliCommand(string commandName, string description, Option<T> option, Action<T> handle, string? alias)
    {
        CommandName = commandName;
        Description = description;
        Handle = handle;
        Option = option;

        if (alias != null)
        {
            option.AddAlias(alias);
        }
    }
}

