namespace NumerologicalLifePath;
public interface ICommand {
    
    public Int16 Result { get; }
    public Client Client { set; }
    void Execute();
}
