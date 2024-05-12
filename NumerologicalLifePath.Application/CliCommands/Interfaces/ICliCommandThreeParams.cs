using System.CommandLine;

namespace NumerologicalLifePath.Application.CliCommands.Interfaces;

internal interface ICliCommandThreeParams<T1, T2, T3>
{
    public Action<T1, T2, T3> Handle { get; }
    public Option<T1> Option1 { get; }
    public Option<T2> Option2 { get; }
    public Option<T3> Option3 { get; }
}

