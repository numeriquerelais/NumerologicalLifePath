using System.Text;

namespace NumerologicalLifePath;
public static class Treatments
{
    private static char Normalize(this char value) 
        => Char.ToUpper(value).ToString().Normalize(NormalizationForm.FormD)[0];

    public static Int16 ConvertToDigit(this char value) {
        var tmp = Char.ToUpper(value);
        var min = Convert.ToInt16('A');
        var max = Convert.ToInt16('Z');

        if (!Char.IsAsciiLetter(value)) {
            tmp = value.Normalize();
        }
        var numTmp = Convert.ToInt16(Char.ToUpper(tmp));
        if (numTmp < min || numTmp > max)
            throw new ArgumentOutOfRangeException($"{value} is not a letter");
        
        return (Int16)(Convert.ToInt16(Char.ToUpper(tmp) - Convert.ToInt16('A')) % 9 + 1);
    }    

    public static Int16 CharAggregate(char[] values, bool reduce=true) {
        Int16 result = 0;
        foreach (char value in values)
        {
            result += value.ConvertToDigit();
        }

        return result > 33 && reduce ? DigitAggregate(result.ToString()) : result;
    }

    public static Int16 DigitAggregate(string values, bool reduce=true) {
        Int16 result = 0;
        foreach (char value in values)
        {
            result += Convert.ToInt16(Char.GetNumericValue(value));
        }

        return result > 33 && reduce ? DigitAggregate(result.ToString()) : result;
    }

    private static readonly char[] Vowels = ['A', 'E', 'I', 'O', 'U', 'Y'];
    private static readonly char[] Consonants = ['B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R','S','T','V', 'W', 'X','Z'];

    public static bool IsVowel(char value) => Vowels.Contains(value.Normalize());
    public static bool IsConsonant(char value) => Consonants.Contains(value.Normalize());
}

