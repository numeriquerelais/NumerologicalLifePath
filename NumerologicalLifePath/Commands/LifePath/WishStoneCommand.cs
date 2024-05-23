using NumerologicalLifePath.Sdk.Abstractions;

namespace NumerologicalLifePath.Sdk.Commands.LifePath;

public sealed class WishStoneCommand() : ACommandWithImputs()
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

        if (Client?.FirstNames != null)
        {
            var firstNames = Client.FirstNames.Where(f => !string.IsNullOrWhiteSpace(f.Trim())).ToList();
            foreach (var firstName in firstNames)
                result.Add(firstName.ToCharArray().Where(letter => Treatments.IsVowel(letter)).ToArray()[0]);
        }

        if (Client?.LastNames != null)
        {
            var lastNames = Client.LastNames.Where(l => !string.IsNullOrWhiteSpace(l.Trim())).ToList();
            foreach (var lastName in lastNames)
                result.Add(lastName.ToCharArray().Where(letter => Treatments.IsVowel(letter)).ToArray()[0]);
        }


        if (result.Count == 0)
            throw new ArgumentException("No vowel found.");

        return [.. result];
    }
}
