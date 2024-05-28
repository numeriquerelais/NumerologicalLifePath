using NFluent;
using NumerologicalLifePath.Application.CliCommands;

namespace NumerologicalLifePath.Tests.Application;

public sealed class InclusionGridCliCommandTests
{
    [Test]
    public void Construct_A_Not_Null_CliCommand()
    {
        var fileInfoCmd = new InclusionGridCliCommand();
        Check.That(fileInfoCmd).IsNotNull().And.IsInstanceOf<InclusionGridCliCommand>();
    }
}
