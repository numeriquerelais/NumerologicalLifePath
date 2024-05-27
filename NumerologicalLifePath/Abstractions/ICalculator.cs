namespace NumerologicalLifePath.Sdk.Abstractions;

public interface ICalculator
{
    public void SetClient(Client client);

    public Task Execute();
}
