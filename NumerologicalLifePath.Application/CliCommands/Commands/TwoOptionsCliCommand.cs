using System.CommandLine;

namespace NumerologicalLifePath.Application.CliCommands.Commands;

public sealed class TwoOptionsCliCommand<T1, T2>
{
    public readonly string CommandName;
    public readonly string Description;
    public readonly Action<T1, T2> Handle;
    public readonly Option<T1> Option1;
    public readonly Option<T2> Option2;

    public TwoOptionsCliCommand(
        string commandName,
        string description,
        Option<T1> option1,
        Option<T2> option2,
        Action<T1, T2> handle,
        string[] aliases)
    {
        CommandName = commandName;
        Description = description;
        Handle = handle;
        Option1 = option1;
        Option2 = option2;

        if (aliases.Length > 0 && aliases.Length != 2)
            throw new ArgumentException("Aliases invalid length. Must be 0 or 2.");
        else if (aliases.Length == 2)
        {
            Option1.AddAlias(aliases[0]);
            Option2.AddAlias(aliases[1]);
        }


    }
}

