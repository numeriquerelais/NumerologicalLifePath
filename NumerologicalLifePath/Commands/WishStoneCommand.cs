namespace NumerologicalLifePath.Commands;

public sealed class WishStoneCommand(Client client) : ACommand(client)
{
    public override void Execute()
    {
        var inputDatas = GetInputDatas();
        _result = Treatments.CharAggregate(inputDatas);
    }

    protected override char[] GetInputDatas()
    {
        var result = new List<char>();

        try
        {
            foreach (var firstName in _client.FirstNames)
                result.Add(firstName.ToCharArray().Where(letter => Treatments.IsVowel(letter)).ToArray()[0]);

            foreach (var lastName in _client.LastNames)
                result.Add(lastName.ToCharArray().Where(letter => Treatments.IsVowel(letter)).ToArray()[0]);
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentException("No Vowel found.");
        }

        return [.. result];
    }
}
