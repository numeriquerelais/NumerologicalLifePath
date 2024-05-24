namespace NumerologicalLifePath.Sdk.Abstractions;
public abstract class ACommand<T> : ICommand<T>
{
    public Client? Client { protected get; set; }
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    protected T _result;
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.

    public T Result { get => _result; }

    public virtual void Execute()
    {
        if (Client == null) throw new InvalidOperationException("Client is null.");
    }

    public void SetClient(Client client)
    {
        Client = client;
    }
}
