namespace NumerologicalLifePath.Sdk.Abstractions;

public abstract class ACalculator(Calculator calculator)
{
    protected readonly Calculator _calculator = calculator;

    public Dictionary<string, short> Calculate(Client clt)
    {
        _calculator.SetClient(clt);
        return _calculator.Results;
    }

    public Dictionary<string, string> CalculateStones(Client clt)
    {
        return Calculate(clt)
            .Select(r => new KeyValuePair<string, string>(r.Key, r.Value.ConvertToStone()))
            .ToDictionary();
    }
}
