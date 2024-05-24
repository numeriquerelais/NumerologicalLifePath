namespace NumerologicalLifePath.Sdk.Abstractions;
public interface ICommand<T>
{

    public T Result { get; }

    public void SetClient(Client client);

    void Execute();
}
