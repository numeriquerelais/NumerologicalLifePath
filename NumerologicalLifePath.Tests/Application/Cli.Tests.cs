using ApprovalTests;
using ApprovalTests.Reporters;
using NFluent;
using NSubstitute;
using NumerologicalLifePath.Application.CliCommands.Interfaces;


namespace NumerologicalLifePath.Application.CliCommands;

[UseReporter(typeof(DiffReporter))]
public sealed class CliTests
{
    private StringWriter _writer;

    private static string[] ConverToArgsArray(string commandLine, string blankCharSubstitute = "#") {
        return commandLine.Split(" ").Select(elmt => elmt.Replace(blankCharSubstitute, " ")).ToArray();
    }

    [SetUp]
    public void Setup() {
        _writer = new();
        Console.SetOut(_writer);
    }

    [TearDown]
    public void TearDown()
    {
        _writer.Dispose();
    }

    [Test]
    public void Construct_A_Not_Null_Cli()
    {
        var cli = new Cli([]);
        Check.That(cli)
            .IsNotNull()
            .And.IsInstanceOf<Cli>();
    }

    [Test]
    public void Failed_To_Construct_Cli_With_Uknown_Type_Of_Command()
    {
        var fakeCmd = Substitute.For<ICliCommand>();
        Check
            .ThatCode(()=> new Cli([fakeCmd]))
            .Throws<ArgumentException>()
            .WithMessage("Not supported command type ObjectProxy.");
    }

    [Test]
    public async Task LifePath_Approval()
    {
        var cli = new Cli([
            new EightLifePathStonesCliCommand()
        ]);

        var args = ConverToArgsArray("lifePath -f Simon#Roger -l Federer#Connors -d 15/02/1955");

        await cli.StartAsync(args);

        Approvals.Verify(_writer.ToString());
    }

    [Test]
    public async Task BirthDateResonance_Approval()
    {
        var cli = new Cli([
            new BirthDateResonanceStonesCliCommand()
        ]);

        var args = ConverToArgsArray("birthStones -d 15/02/1955");

        await cli.StartAsync(args);

        Approvals.Verify(_writer.ToString());
    }
}
