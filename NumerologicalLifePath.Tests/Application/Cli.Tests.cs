using ApprovalTests;
using ApprovalTests.Reporters;
using NFluent;
using NSubstitute;
using NumerologicalLifePath.Application.CliCommands.Interfaces;
using System.CommandLine.Parsing;


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
    public void Should_Construct_A_Not_Null_Cli()
    {
        var cli = new Cli([]);
        Check.That(cli)
            .IsNotNull()
            .And.IsInstanceOf<Cli>();
    }

    [Test]
    public void Should_Not_Construct_Cli_With_Uknown_Type_Of_Command()
    {
        var fakeCmd = Substitute.For<ICliCommand>();
        Check
            .ThatCode(()=> new Cli([fakeCmd]))
            .Throws<ArgumentException>()
            .WithMessage("Not supported command type ObjectProxy.");
    }

    [Test]
    public async Task Should_Execute_LifePath_Command_With_ddMMyyyy_Arg_Approval_Test()
    {
        var cli = new Cli([
            new EightLifePathStonesCliCommand()
        ]);

        var args = ConverToArgsArray("lifePath -f Simon#Roger -l Federer#Connors -d 15/02/1955");

        await cli.StartAsync(args);

        Approvals.Verify(_writer.ToString());
    }

    [Test]
    public async Task Should_Display_Help_Of_LifePath_Command_Approval_Test()
    {
        var cli = new Cli([
            new EightLifePathStonesCliCommand()
        ]);

        var args = ConverToArgsArray("lifePath -h");

        await cli.StartAsync(args);

        Approvals.Verify(_writer.ToString());
    }

    [Test]
    public void Should_Not_Execute_LifePath_Command_With_Not_Parsable_DateOnly()
    {
        var cli = new Cli([
            new EightLifePathStonesCliCommand()
        ]);

        var args = ConverToArgsArray("lifePath -f Simon#Roger -l Federer#Connors -d 15,02,1955");

        Check
            .ThatCode(async() => await cli.StartAsync(args))
        .Throws<CannotParseArugmentException>()
            .WithMessage("Cannot parse argument '15,02,1955' as expected type 'System.DateOnly'.");
    }

    [Test]
    public async Task Should_Execute_BirthDateResonance_Command_With_ddMMyyyy_Approval_Test()
    {
        var cli = new Cli([
            new BirthDateResonanceStonesCliCommand()
        ]);

        var args = ConverToArgsArray("birthStones -d 15/02/1955");

        await cli.StartAsync(args);

        Approvals.Verify(_writer.ToString());
    }

    [Test]
    public async Task Should_Execute_BirthDateResonance_Command_With_MMddyyyy_Approval_Test()
    {
        var cli = new Cli([
            new BirthDateResonanceStonesCliCommand()
        ]);

        var args = ConverToArgsArray("birthStones -d 02.15.1955");

        await cli.StartAsync(args);

        Approvals.Verify(_writer.ToString());
    }

    [Test]
    public async Task Should_Display_Help_Of_BirthDateResonance_Command_Approval_Test()
    {
        var cli = new Cli([
            new BirthDateResonanceStonesCliCommand()
        ]);

        var args = ConverToArgsArray("birthStones -h");

        await cli.StartAsync(args);

        Approvals.Verify(_writer.ToString());
    }

    [Test]
    public async Task Should_Execute_BirthDateResonance_Command_With_yyyyMMdd_Approval_Test()
    {
        var cli = new Cli([
            new BirthDateResonanceStonesCliCommand()
        ]);

        var args = ConverToArgsArray("birthStones -d 1955-02-15");

        await cli.StartAsync(args);

        Approvals.Verify(_writer.ToString());
    }
    [Test]
    public void Should_Not_Execute_BirthDateResonance_Command_With_Not_Parsable_DateOnly()
    {
        var cli = new Cli([
            new BirthDateResonanceStonesCliCommand()
        ]);

        var args = ConverToArgsArray("birthStones -d 1955,02,15");

        Check
            .ThatCode(async () => await cli.StartAsync(args))
        .Throws<CannotParseArugmentException>()
            .WithMessage("Cannot parse argument '1955,02,15' as expected type 'System.DateOnly'.");
    }

}
