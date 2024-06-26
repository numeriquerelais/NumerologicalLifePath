﻿namespace NumerologicalLifePath.Sdk.Abstractions;
public abstract class ACompoundCommand(List<ICommand<short>> commands, bool reduceAggregate) : ICommand<short>
{
    protected readonly List<ICommand<short>> _commands = commands;
    protected readonly bool _reduceAggregate = reduceAggregate;

    protected short _result = -1;

    public short Result { get => _result; }

    public void Execute()
    {
        short results = 0;

        foreach (var command in _commands)
        {
            command.Execute();
            results += command.Result;
        }

        _result = _reduceAggregate ? Treatments.DigitAggregate(results.ToString()) : results;
    }

    public void SetClient(Client client)
    {
        foreach (var command in _commands)
            command.SetClient(client);
    }
}
