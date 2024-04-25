namespace NumerologicalLifePath;
public interface ICommand {
    
    public Int16 Result { get; }

    void Execute();
}
