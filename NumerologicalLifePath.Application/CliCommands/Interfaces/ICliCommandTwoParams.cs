using System.CommandLine;

namespace NumerologicalLifePath.Application.CliCommands.Interfaces;

internal interface ICliCommandTwoParams<T1, T2>
{
    public Action<T1, T2> Handle { get; }
    public Option<T1> Option1 { get; }
    public Option<T2> Option2 { get; }
}

