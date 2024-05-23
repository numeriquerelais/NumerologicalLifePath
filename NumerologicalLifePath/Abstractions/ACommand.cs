namespace NumerologicalLifePath.Sdk.Abstractions;
public abstract class ACommand : ICommand
{
    public Client? Client { protected get; set; }
    protected short _result = -1;

    public short Result { get => _result; }

    public virtual void Execute()
    {
        if (Client == null) throw new InvalidOperationException("Client is null.");
    }

    public void SetClient(Client client)
    {
        Client = client;
    }
}
