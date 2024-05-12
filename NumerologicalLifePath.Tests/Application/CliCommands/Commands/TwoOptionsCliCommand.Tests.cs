using NFluent;
using NumerologicalLifePath.Application.CliCommands.Commands;
using System.CommandLine;

namespace NumerologicalLifePath.Tests.Application.CliCommands.Commands;

public sealed class TwoOptionsCliCommandTests
{
    [Test]
    public void Construct_A_Not_Null_TwoOptionsCliCommand()
    {
        string delegateStringResult = string.Empty;
        int delegateIntResult = 0;

        var cmd = new TwoOptionsCliCommand<string, int>(
                "name",
                "descprition",
                new Option<string>(
                    name: "--option1",
                    description: "option1 description"
                ),
                new Option<int>(
                    name: "--option2",
                    description: "option2 description"
                ),
                delegate (string str, int i) {
                    delegateStringResult = str;
                    delegateIntResult = i;
                },
                ["-o1","-o2"]
            );

        Check.That(cmd)
            .IsNotNull()
            .And.IsInstanceOf<TwoOptionsCliCommand<string, int>>();

        Check.That(cmd.CommandName).Equals("name");
        Check.That(cmd.Description).Equals("descprition");

        Check.That(cmd.Option1)
            .IsNotNull()
            .And.IsInstanceOf<Option<string>>();

        Check.That(cmd.Option1.Name).Equals("option1");
        Check.That(cmd.Option1.Description).Equals("option1 description");
        Check.That(cmd.Option1.Aliases).ContainsExactly(["--option1", "-o1"]);

        Check.That(cmd.Option2)
            .IsNotNull()
            .And.IsInstanceOf<Option<int>>();

        Check.That(cmd.Option2.Name).Equals("option2");
        Check.That(cmd.Option2.Description).Equals("option2 description");
        Check.That(cmd.Option2.Aliases).ContainsExactly(["--option2", "-o2"]);

        Check.That(cmd.Handle)
            .IsNotNull()
            .And.IsInstanceOf<Action<string, int>>();

        cmd.Handle("value",1);

        Check.That(delegateStringResult).Equals("value");
        Check.That(delegateIntResult).Equals(1);
    }

    [Test]
    public void Construct_A_Not_Null_TwoOptionsCliCommand_Without_Alias()
    {
        var cmd = new TwoOptionsCliCommand<string, string>(
                "name",
                "descprition",
                new Option<string>("name1"),
                new Option<string>("name2"),
                delegate (string str1, string str2) { },
                []
            );

        Check.That(cmd.Option1.Aliases).ContainsExactly(["name1"]);
        Check.That(cmd.Option2.Aliases).ContainsExactly(["name2"]);
    }

    [Test]
    public void Failed_To_Construct_A_TwoOptionsCliCommand_Without_Correct_Aliases_Length()
    {
        Check.ThatCode(() =>
        {
            _ = new TwoOptionsCliCommand<string, string>(
                "name",
                "descprition",
                new Option<string>("name1"),
                new Option<string>("name2"),
                delegate (string str1, string str2) { },
                ["-a"]
            );
        })
            .Throws<ArgumentException>()
            .WithMessage("Aliases invalid length. Must be 0 or 2.");
    }
}
