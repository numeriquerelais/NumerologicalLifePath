namespace NumerologicalLifePath;
public abstract class ACommand(Client client) : ICommand
{
    protected readonly Client _client = client;
    protected Int16 _result = -1;

    public Int16 Result { get => _result; }

    public abstract void Execute();

    protected abstract char[] GetInputDatas();
}
