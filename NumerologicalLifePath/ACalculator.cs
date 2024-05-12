namespace NumerologicalLifePath;

public abstract class ACalculator
{
    protected readonly Calculator _calculator;
    protected ACalculator(Calculator calculator)
    {
        _calculator = calculator;
    }

    public Dictionary<string, Int16> Calculate(Client clt)
    {
        _calculator.SetClient(clt);
        return _calculator.Results;
    }

    public Dictionary<string, string> CalculateStones(Client clt)
    {
        return Calculate(clt)
            .Select(r => new KeyValuePair<string, string>(r.Key, r.Value.ConvertToStone()))
            .ToDictionary<string, string>();
    }
}
