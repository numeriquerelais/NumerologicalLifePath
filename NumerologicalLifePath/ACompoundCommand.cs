namespace NumerologicalLifePath;
public abstract class ACompoundCommand(List<ICommand> commands, bool reduceAggregate) : ICommand
{
    protected readonly List<ICommand> _commands = commands;
    protected readonly bool _reduceAggregate = reduceAggregate;

    protected Int16 _result = -1;

    public Int16 Result { get => _result; }

    public void Execute() {
        Int16 results = 0;
  
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
