using System.CommandLine;

namespace NumerologicalLifePath.Application.CliCommands.Commands;

public sealed class ThreeOptionsCliCommand<T1, T2, T3>
{
    public readonly string CommandName;
    public readonly string Description;
    public readonly Action<T1, T2, T3> Handle;
    public readonly Option<T1> Option1;
    public readonly Option<T2> Option2;
    public readonly Option<T3> Option3;

    public ThreeOptionsCliCommand(
        string commandName,
        string description,
        Option<T1> option1,
        Option<T2> option2,
        Option<T3> option3,
        Action<T1, T2, T3> handle,
        string[] aliases)
    {
        CommandName = commandName;
        Description = description;
        Handle = handle;
        Option1 = option1;
        Option2 = option2;
        Option3 = option3;

        if (aliases.Length > 0 && aliases.Length != 3)
            throw new ArgumentException("Aliases invalid length. Must be 0 or 3.");
        else if (aliases.Length == 3)
        {
            Option1.AddAlias(aliases[0]);
            Option2.AddAlias(aliases[1]);
            Option3.AddAlias(aliases[2]);
        }


    }
}

