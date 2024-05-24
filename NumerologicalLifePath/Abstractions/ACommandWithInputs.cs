namespace NumerologicalLifePath.Sdk.Abstractions;
public abstract class ACommandWithImputs : ACommand<short>
{
    protected abstract char[] GetInputDatas();
}
