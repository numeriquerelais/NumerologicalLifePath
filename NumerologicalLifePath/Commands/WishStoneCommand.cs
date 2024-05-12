namespace NumerologicalLifePath.Commands;

public sealed class WishStoneCommand() : ACommand()
{
    public override void Execute()
    {
        base.Execute();
        var inputDatas = GetInputDatas();
        _result = Treatments.CharAggregate(inputDatas);
    }

    protected override char[] GetInputDatas()
    {
        var result = new List<char>();

        try
        {
            foreach (var firstName in Client!.FirstNames)
                result.Add(firstName.ToCharArray().Where(letter => Treatments.IsVowel(letter)).ToArray()[0]);

            foreach (var lastName in Client!.LastNames)
                result.Add(lastName.ToCharArray().Where(letter => Treatments.IsVowel(letter)).ToArray()[0]);
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentException("No Vowel found.");
        }

        return [.. result];
    }
}
