namespace NumerologicalLifePath.Sdk.Abstractions;
public interface ICommand<out T>
{

    public T Result { get; }

    public void SetClient(Client client);

    void Execute();
}
