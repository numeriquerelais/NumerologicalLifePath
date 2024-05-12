using NFluent;
using System.Text;

namespace NumerologicalLifePath.Tests.Sdk
{
    public sealed class TreatmentsTests
    {
        [TestCase(65, 1)]//'A'
        [TestCase(66, 2)]//'B'
        [TestCase(75, 2)]//'K'
        [TestCase(85, 3)]//'U'
        [TestCase(77, 4)]//'M'
        [TestCase(69, 5)]//'E'
        [TestCase(101, 5)]//'e'
        [TestCase(88, 6)]//'X'
        [TestCase(80, 7)]//'P'
        [TestCase(72, 8)]//'H'
        [TestCase(82, 9)]//'R'
        [TestCase(232, 5)]//'é'
        [TestCase(233, 5)]//'è'
        [TestCase(224, 1)]//'à'
        [TestCase(250, 3)]//'ù'
        [TestCase(105, 9)]//'i'
        [TestCase(239, 9)]//'ï'
        [TestCase(238, 9)]//'î'
        [TestCase(236, 9)]//'ì'
        [TestCase(231, 3)]//'ç' 
        public void Should_Convert_Letter_To_Figure(short decimalValue, short expectedFigure)
        {
            char letter = Convert.ToChar(decimalValue);
            Check.That(letter.ConvertToDigit()).Equals(expectedFigure);
        }

        [TestCase(137)]//'_'
        [TestCase(55)]//'7'
        [TestCase(42)]//'*'
        [TestCase(36)]//'$'
        [TestCase(64)]//'@'
        [TestCase(156)]//'œ'        
        public void Should_Not_Convert_Letter_To_Figure(short decimalValue)
        {
            char letter = Convert.ToChar(decimalValue);
            Check.ThatCode(() => letter.ConvertToDigit())
                .Throws<ArgumentOutOfRangeException>()
                .WithMessage($"Specified argument was out of the range of valid values. (Parameter '{letter} is not a letter')");
            ;
        }

        [TestCase("Marie", "41995")]
        [TestCase("Dupont", "437652")]
        [TestCase("Martin", "419295")]
        public void Should_Convert_FirstName_To_Numerics(string firstName, string expectedResult)
        {
            StringBuilder buffer = new();
            foreach (char letter in firstName)
            {
                buffer.Append(letter.ConvertToDigit());
            }

            Check.That(buffer.ToString()).ContainsExactly(expectedResult);
        }

        [TestCase("NELO", 19)]
        [TestCase("MSAQM", 18)]
        [TestCase("RPMT", 22)]
        [TestCase("OAIIEEIEIAO", 11)]
        [TestCase("RMNPRRMCHLTG", 7)]
        [TestCase("ieoaaoaaoaao", 8)]
        [TestCase("DgrmndMrdnFrnc", 15)]
        [TestCase("iaaa", 12)]
        [TestCase("yeoa", 19)]
        [TestCase("yieueeoioauoi", 11)]
        [TestCase("aieioeaoieeuaaooeau", 15)]
        public void Should_Agregate_Letters_To_Numerics(string letters, int expectedResult)
        {
            Check.That(Treatments.CharAggregate(letters.ToCharArray())).Equals(expectedResult);
        }

        [TestCase("NELO", 19)]
        [TestCase("RPMT", 22)]
        [TestCase("OAIIEEIEIAO", 65)]
        [TestCase("RMNPRRMCHLTG", 70)]
        [TestCase("ieoaaoaaoaao", 44)]
        [TestCase("DgrmndMrdnFrnc", 78)]
        [TestCase("yieueeoioauoi", 74)]
        [TestCase("aieioeaoieeuaaooeau", 87)]
        public void Should_Agregate_Letters_To_Not_Reduced_Numerics(string letters, int expectedResult)
        {
            Check.That(Treatments.CharAggregate(letters.ToCharArray(), false)).Equals(expectedResult);
        }

        [TestCase(65)]//'A'
        [TestCase(69)]//'E'
        [TestCase(101)]//'e'
        [TestCase(73)]//'I'
        [TestCase(79)]//'O'
        [TestCase(85)]//'U'
        [TestCase(89)]//'Y'
        [TestCase(121)]//'y'
        [TestCase(233)]//'é'
        [TestCase(232)]//'è'
        [TestCase(225)]//'à'
        [TestCase(249)]//'ù'
        [TestCase(105)]//'i'
        [TestCase(239)]//'ï'
        [TestCase(238)]//'î'
        [TestCase(236)]//'ì'
        public void Should_Find_Letter_Is_Vowel(short decimalValue)
        {
            char letter = Convert.ToChar(decimalValue);
            Check.That(Treatments.IsVowel(letter)).IsTrue();
        }

        [TestCase(66)]//'B'
        [TestCase(98)]//'b'
        [TestCase(67)]//'C'
        [TestCase(68)]//'D'
        [TestCase(70)]//'F'
        [TestCase(71)]//'G'
        [TestCase(104)]//'h'
        [TestCase(72)]//'H'
        [TestCase(74)]//'J'
        [TestCase(75)]//'K'
        [TestCase(76)]//'L'
        [TestCase(77)]//'M'
        [TestCase(110)]//'n'
        [TestCase(241)]//'ñ'
        [TestCase(80)]//'P'
        [TestCase(113)]//'q'
        [TestCase(82)]//'R'
        [TestCase(83)]//'S'
        [TestCase(84)]//'T'
        [TestCase(86)]//'V'
        [TestCase(87)]//'W'
        [TestCase(120)]//'x'
        [TestCase(90)]//'Z'
        public void Should_Find_Letter_Is_Not_A_Vowel(short decimalValue)
        {
            char letter = Convert.ToChar(decimalValue);
            Check.That(Treatments.IsVowel(letter)).IsFalse();
        }

        [TestCase(66)]//'B'
        [TestCase(98)]//'b'
        [TestCase(67)]//'C'
        [TestCase(68)]//'D'
        [TestCase(70)]//'F'
        [TestCase(71)]//'G'
        [TestCase(104)]//'h'
        [TestCase(72)]//'H'
        [TestCase(74)]//'J'
        [TestCase(75)]//'K'
        [TestCase(76)]//'L'
        [TestCase(77)]//'M'
        [TestCase(110)]//'n'
        [TestCase(241)]//'ñ'
        [TestCase(80)]//'P'
        [TestCase(113)]//'q'
        [TestCase(82)]//'R'
        [TestCase(83)]//'S'
        [TestCase(84)]//'T'
        [TestCase(86)]//'V'
        [TestCase(87)]//'W'
        [TestCase(120)]//'x'
        [TestCase(90)]//'Z'
        public void Should_Find_Letter_Is_A_Consonant(short decimalValue)
        {
            char letter = Convert.ToChar(decimalValue);
            Check.That(Treatments.IsConsonant(letter)).IsTrue();
        }

        [TestCase(65)]//'A'
        [TestCase(69)]//'E'
        [TestCase(101)]//'e'
        [TestCase(73)]//'I'
        [TestCase(79)]//'O'
        [TestCase(85)]//'U'
        [TestCase(89)]//'Y'
        [TestCase(121)]//'y'
        [TestCase(233)]//'é'
        [TestCase(232)]//'è'
        [TestCase(225)]//'à'
        [TestCase(249)]//'ù'
        [TestCase(105)]//'i'
        [TestCase(239)]//'ï'
        [TestCase(238)]//'î'
        [TestCase(236)]//'ì'
        public void Should_Find_Letter_Is_Not_A_Consonant(short decimalValue)
        {
            char letter = Convert.ToChar(decimalValue);
            Check.That(Treatments.IsConsonant(letter)).IsFalse();
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        [TestCase(6, 6)]
        [TestCase(7, 7)]
        [TestCase(8, 8)]
        [TestCase(9, 9)]
        [TestCase(10, 1)]
        [TestCase(29, 2)]
        [TestCase(48, 3)]
        [TestCase(67, 4)]
        [TestCase(86, 5)]
        [TestCase(15, 6)]
        [TestCase(34, 7)]
        [TestCase(53, 8)]
        [TestCase(72, 9)]
        [TestCase(256, 4)]
        public void Should_Get_Numerological_Resonance_Of_Digit(short value, short expectedResult)
        {
            Check.That(value.NumerologicalResonance()).Equals(expectedResult);
        }


        [TestCase(8, 2, 1968, 7)]
        [TestCase(20, 4, 1985, 11)]
        [TestCase(9, 6, 1996, 4)]
        [TestCase(10, 9, 1990, 11)]
        [TestCase(24, 2, 1978, 33)]
        [TestCase(29, 4, 2014, 22)]
        public void Should_Get_Numerological_Resonance_Of_Date(short day, short month, short year, short expectedResult)
        {
            var date = new DateOnly(year, month, day);
            Check.That(date.NumerologicalResonance()).Equals(expectedResult);
        }

        [TestCase(1, "Pink Quartz")]
        [TestCase(29, "Sodalite")]
        [TestCase(20, "Lapis Lazuli")]
        [TestCase(33, "Tourmalinated Quartz")]
        public void Should_Convert_Number_To_Stone(short number, string expectedStoneName)
        {
            Check.That(number.ConvertToStone()).Equals(expectedStoneName);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(34)]
        public void Should_Not_Convert_Number_To_Stone(short number)
        {
            Check.ThatCode(() => number.ConvertToStone())
                .Throws<IndexOutOfRangeException>()
                .WithMessage("Index was outside the bounds of the array.");
        }
    }
}