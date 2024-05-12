using NFluent;
using NumerologicalLifePath.Application.CliCommands.Commands;
using System.CommandLine;

namespace NumerologicalLifePath.Tests.Application.CliCommands.Commands;

public sealed class ThreeOptionsCliCommandTests
{
    [Test]
    public void Construct_A_Not_Null_ThreeOptionsCliCommand()
    {
        string delegateStringResult = string.Empty;
        int delegateIntResult = 0;
        bool delegateBoolResult = false;

        var cmd = new ThreeOptionsCliCommand<string, int, bool>(
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
                new Option<bool>(
                    name: "--option3",
                    description: "option3 description"
                ),
                delegate (string str, int i, bool b) {
                    delegateStringResult = str;
                    delegateIntResult = i;
                    delegateBoolResult = b;
                },
                ["-o1","-o2", "-o3"]
            );

        Check.That(cmd)
            .IsNotNull()
            .And.IsInstanceOf<ThreeOptionsCliCommand<string, int, bool>>();

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

        Check.That(cmd.Option3)
            .IsNotNull()
            .And.IsInstanceOf<Option<bool>>();

        Check.That(cmd.Option3.Name).Equals("option3");
        Check.That(cmd.Option3.Description).Equals("option3 description");
        Check.That(cmd.Option3.Aliases).ContainsExactly(["--option3", "-o3"]);

        Check.That(cmd.Handle)
            .IsNotNull()
            .And.IsInstanceOf<Action<string, int, bool>>();

        cmd.Handle("value",1, true);

        Check.That(delegateStringResult).Equals("value");
        Check.That(delegateIntResult).Equals(1);
        Check.That(delegateBoolResult).IsTrue();
    }

    [Test]
    public void Construct_A_Not_Null_ThreeOptionsCliCommand_Without_Alias()
    {
        var cmd = new ThreeOptionsCliCommand<string, string, string>(
                "name",
                "descprition",
                new Option<string>("name1"),
                new Option<string>("name2"),
                new Option<string>("name3"),
                delegate (string str1, string str2, string str3) { },
                []
            );

        Check.That(cmd.Option1.Aliases).ContainsExactly(["name1"]);
        Check.That(cmd.Option2.Aliases).ContainsExactly(["name2"]);
    }

    [Test]
    public void Failed_To_Construct_A_ThreeOptionsCliCommand_Without_Correct_Aliases_Length()
    {
        Check.ThatCode(() =>
        {
            _ = new ThreeOptionsCliCommand<string, string, string>(
                "name",
                "descprition",
                new Option<string>("name1"),
                new Option<string>("name2"),
                new Option<string>("name3"),
                delegate (string str1, string str2, string str3) { },
                ["-a"]
            );
        })
            .Throws<ArgumentException>()
            .WithMessage("Aliases invalid length. Must be 0 or 3.");
    }
}
