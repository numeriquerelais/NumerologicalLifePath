namespace NumerologicalLifePath;
public abstract class ACommand : ICommand{
    public Client? Client { protected get; set; }
    protected Int16 _result = -1;

    public Int16 Result { get => _result; }

    public virtual void Execute() {
        if (Client == null) throw new ArgumentNullException("Client is null.");
    }

    protected abstract char[] GetInputDatas();
}
