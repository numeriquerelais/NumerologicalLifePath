using NFluent;
using NumerologicalLifePath.Application.CliCommands;

namespace NumerologicalLifePath.Tests.Application;

public sealed class BirthDateResonanceStonesCliCommandTests
{
    [Test]
    public void Construct_A_Not_Null_CliCommand()
    {
        var fileInfoCmd = new BirthDateResonanceStonesCliCommand();
        Check.That(fileInfoCmd).IsNotNull().And.IsInstanceOf<BirthDateResonanceStonesCliCommand>();
    }
}
