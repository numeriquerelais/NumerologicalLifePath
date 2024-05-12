using NFluent;
using NumerologicalLifePath.Application.CliCommands.Commands;
using System.CommandLine;

namespace NumerologicalLifePath.Tests.Application.CliCommands.Commands;

public sealed class SingleOptionCliCommandTests
{
    [Test]
    public void Construct_A_Not_Null_SingleOptionCliCommand()
    {
        string delegateResult = string.Empty;
        var cmd = new SingleOptionCliCommand<string>(
                "name",
                "descprition",
                new Option<string>(
                    name: "--option",
                    description: "option description"
                ),
                delegate (string str) { 
                    delegateResult = str; 
                },
                "-o"
            );

        Check.That(cmd)
            .IsNotNull()
            .And.IsInstanceOf<SingleOptionCliCommand<string>>();

        Check.That(cmd.CommandName).Equals("name");
        Check.That(cmd.Description).Equals("descprition");

        Check.That(cmd.Option)
            .IsNotNull()
            .And.IsInstanceOf<Option<string>>();

        Check.That(cmd.Option.Name).Equals("option");
        Check.That(cmd.Option.Description).Equals("option description");
        Check.That(cmd.Option.Aliases).ContainsExactly(["--option", "-o"]);

        Check.That(cmd.Handle)
            .IsNotNull()
            .And.IsInstanceOf<Action<string>>();

        cmd.Handle("value");

        Check.That(delegateResult).Equals("value");

    }

    [Test]
    public void Construct_A_Not_Null_SingleOptionCliCommand_Without_Alias()
    {
        var cmd = new SingleOptionCliCommand<string>(
                "name",
                "descprition",
                new Option<string>(
                    name: "--option",
                    description: "option description"
                ),
                delegate (string str) {},
                null
            );
        
        Check.That(cmd.Option.Aliases).ContainsExactly(["--option"]);

    }
}
