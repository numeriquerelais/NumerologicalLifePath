using System.Text;

namespace NumerologicalLifePath.Sdk;
public static class Treatments
{
    private static char Normalize(this char value)
        => char.ToUpper(value).ToString().Normalize(NormalizationForm.FormD)[0];

    public static short ConvertToDigit(this char value)
    {
        var tmp = char.ToUpper(value);
        var min = Convert.ToInt16('A');
        var max = Convert.ToInt16('Z');

        if (!char.IsAsciiLetter(tmp))
        {
            tmp = value.Normalize();
        }
        var numTmp = Convert.ToInt16(tmp);
        if (numTmp < min || numTmp > max)
            throw new ArgumentOutOfRangeException($"{value} is not a letter");

        return (short)(Convert.ToInt16(tmp - Convert.ToInt16('A')) % 9 + 1);
    }

    public static short CharAggregate(char[] values, bool reduce = true)
    {
        short result = 0;
        foreach (char value in values)
        {
            result += value.ConvertToDigit();
        }

        return result > 33 && reduce ? DigitAggregate(result.ToString()) : result;
    }

    public static short DigitAggregate(string values, bool reduce = true)
    {
        short result = 0;
        foreach (char value in values)
        {
            result += Convert.ToInt16(char.GetNumericValue(value));
        }

        return result > 33 && reduce ? DigitAggregate(result.ToString()) : result;
    }

    private static readonly char[] Vowels = ['A', 'E', 'I', 'O', 'U', 'Y'];
    private static readonly char[] Consonants = ['B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z'];
    private static readonly string[] Stones = [
        "Pink Quartz",
        "Red Jasper",
        "Chalcedony",
        "Jade",
        "Emerald",
        "Garnet",
        "Citrine",
        "Obsidian",
        "Aquamarine",
        "Rhodochrosite",
        "Carnelian",
        "Amber",
        "Hematite",
        "Amethyst",
        "Malachite",
        "Opal",
        "Turquoise",
        "Moonstone",
        "Topaz",
        "Lapis Lazuli",
        "Tourmaline",
        "Rock Crystal",
        "Azurite",
        "Amazonite",
        "Tiger's Eye",
        "Pyrite",
        "Fluorite",
        "Pearl",
        "Sodalite",
        "Smoky Quartz",
        "Moonstone",
        "Mokaite",
        "Tourmalinated Quartz",
        ];

    public static bool IsVowel(char value) => Vowels.Contains(value.Normalize());
    public static bool IsConsonant(char value) => Consonants.Contains(value.Normalize());

    public static string ConvertToStone(this short value)
    {
        return Stones[value - 1];
    }

    public static short NumerologicalResonance(this short value)
    {
        var result = value % 9;
        return result == 0 ? (short)9 : (short)result;
    }

    public static short NumerologicalResonance(this DateOnly date)
    {
        var day = ((short)date.Day).NumerologicalResonance();
        var month = ((short)date.Month).NumerologicalResonance();
        var year = ((short)date.Year).NumerologicalResonance();

        var sum = day + month + year;
        var key33 = DigitAggregate(date.Day.ToString() + date.Month.ToString() + date.Year.ToString());

        if (key33 % 33 == 0) return 33;

        var key22 = key33 > 22 ? DigitAggregate(key33.ToString()) : key33;

        if (key22 % 22 == 0) return 22;

        var key11 = key33 > 11 ? DigitAggregate(key33.ToString()) : key33;
        if (key11 % 11 == 0) return 11;
        return ((short)sum).NumerologicalResonance();
    }
}

