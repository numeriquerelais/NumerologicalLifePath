namespace NumerologicalLifePath;
public interface ICommand {
    
    public Int16 Result { get; }

    public void SetClient(Client client);

    void Execute();
}
