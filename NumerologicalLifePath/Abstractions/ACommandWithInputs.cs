namespace NumerologicalLifePath.Sdk.Abstractions;
public abstract class ACommandWithImputs : ACommand
{
    protected abstract char[] GetInputDatas();
}
