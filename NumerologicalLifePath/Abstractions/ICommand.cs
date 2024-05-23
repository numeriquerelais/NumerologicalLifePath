namespace NumerologicalLifePath.Sdk.Abstractions;
public interface ICommand
{

    public short Result { get; }

    public void SetClient(Client client);

    void Execute();
}
