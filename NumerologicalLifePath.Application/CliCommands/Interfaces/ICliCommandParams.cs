using System.CommandLine;

namespace NumerologicalLifePath.Application.CliCommands.Interfaces;

public interface ICliCommandParams<T>
{
   
    public Action<T> Handle { get; }
    public Option<T> Option { get; }
}