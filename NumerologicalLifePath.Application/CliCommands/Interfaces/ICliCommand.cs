namespace NumerologicalLifePath.Application.CliCommands.Interfaces;
public interface ICliCommand {
    public string CommandName { get; }
    public string Description { get; }
}
