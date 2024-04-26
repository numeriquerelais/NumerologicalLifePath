using NFluent;
using System.Text;

namespace NumerologicalLifePath.Tests
{
    public sealed class TreatmentsTests
    {
        [TestCase('A', 1)]
        [TestCase('B', 2)]
        [TestCase('K', 2)]
        [TestCase('U', 3)]
        [TestCase('M', 4)]
        [TestCase('E', 5)]
        [TestCase('e', 5)]
        [TestCase('X', 6)]
        [TestCase('P', 7)]
        [TestCase('H', 8)]
        [TestCase('R', 9)]
        [TestCase('é', 5)]
        [TestCase('è', 5)]
        [TestCase('à', 1)]
        [TestCase('ù', 3)]
        [TestCase('i', 9)]
        [TestCase('ï', 9)]
        [TestCase('î', 9)]
        [TestCase('ì', 9)]
        [TestCase('š', 1)]        
        public void Should_Convert_Letter_To_Figure(char letter, Int16 expectedFigure)
        {
            Check.That(letter.ConvertToDigit()).Equals(expectedFigure);
        }

        [TestCase('_')]
        [TestCase('7')]
        [TestCase('*')]
        [TestCase('$')]
        [TestCase('@')]
        [TestCase('œ')]        
        public void Should_Not_Convert_Letter_To_Figure(char value)
        {
            Check.ThatCode(() => value.ConvertToDigit())
                .Throws<ArgumentOutOfRangeException>()
                .WithMessage($"Specified argument was out of the range of valid values. (Parameter '{value} is not a letter')");
;
        }

        [TestCase("Marie", "41995")]
        [TestCase("Dupont", "437652")]
        [TestCase("Martin", "419295")]
        public void Should_Convert_FirstName_To_Numerics(string firstName, string expectedResult)
        {
            StringBuilder buffer = new();
            foreach (char letter in firstName) { 
                buffer.Append(letter.ConvertToDigit());
            }

            Check.That(buffer.ToString()).ContainsExactly(expectedResult);
        }

        [TestCase("NELO", 19)]
        [TestCase("MSAQM", 18)]
        [TestCase("RPMT", 22)]
        [TestCase("OAIIEEIEIAO",11)]
        [TestCase("RMNPRRMCHLTG", 7)]
        [TestCase("ieoaaoaaoaao", 8)]
        [TestCase("DgrmndMrdnFrnc", 15)]
        [TestCase("iaaa", 12)]
        [TestCase("yeoa", 19)]
        [TestCase("yieueeoioauoi", 11)]
        [TestCase("aieioeaoieeuaaooeau", 15)]        
        public void Should_Agregate_Letters_To_Numerics(string letters, int expectedResult) {
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

        [TestCase('A')]
        [TestCase('E')]
        [TestCase('e')]
        [TestCase('I')]
        [TestCase('O')]
        [TestCase('U')]
        [TestCase('Y')]
        [TestCase('y')]
        [TestCase('é')]
        [TestCase('è')]
        [TestCase('à')]
        [TestCase('ù')]
        [TestCase('i')]
        [TestCase('ï')]
        [TestCase('î')]
        [TestCase('ì')]
        public void Should_Find_Letter_Is_Vowel(char letter)
        {
            Check.That(Treatments.IsVowel(letter)).IsTrue();
        }

        [TestCase('B')]
        [TestCase('b')]
        [TestCase('C')]
        [TestCase('D')]
        [TestCase('F')]
        [TestCase('G')]
        [TestCase('h')]
        [TestCase('H')]
        [TestCase('J')]
        [TestCase('K')]
        [TestCase('L')]
        [TestCase('M')]
        [TestCase('n')]
        [TestCase('ñ')]
        [TestCase('P')]
        [TestCase('q')]
        [TestCase('R')]
        [TestCase('S')]
        [TestCase('T')]
        [TestCase('V')]
        [TestCase('W')]
        [TestCase('x')]
        [TestCase('Z')]
        public void Should_Find_Letter_Is_Not_A_Vowel(char letter)
        {
            Check.That(Treatments.IsVowel(letter)).IsFalse();
        }

        [TestCase('B')]
        [TestCase('b')]
        [TestCase('C')]
        [TestCase('ç')]
        [TestCase('D')]
        [TestCase('F')]
        [TestCase('G')]
        [TestCase('h')]
        [TestCase('H')]
        [TestCase('J')]
        [TestCase('K')]
        [TestCase('L')]
        [TestCase('M')]
        [TestCase('n')]
        [TestCase('P')]
        [TestCase('q')]
        [TestCase('R')]
        [TestCase('S')]
        [TestCase('T')]
        [TestCase('V')]
        [TestCase('W')]
        [TestCase('x')]
        [TestCase('Z')]
        public void Should_Find_Letter_Is_A_Consonant(char letter)
        {
            Check.That(Treatments.IsConsonant(letter)).IsTrue();
        }

        [TestCase('A')]
        [TestCase('E')]
        [TestCase('e')]
        [TestCase('I')]
        [TestCase('O')]
        [TestCase('U')]
        [TestCase('Y')]
        [TestCase('y')]
        [TestCase('à')]
        [TestCase('ù')]
        [TestCase('i')]
        public void Should_Find_Letter_Is_Not_A_Consonant(char letter)
        {
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
        public void Should_Get_Numerological_Resonance_Of_Digit(Int16 value, Int16 expectedResult)
        {
            Check.That(value.NumerologicalResonance()).Equals(expectedResult);
        }


        [TestCase(8, 2, 1968, 7)]
        [TestCase(20, 4, 1985, 11)]
        [TestCase(9, 6, 1996, 4)]
        [TestCase(10, 9, 1990, 11)]
        [TestCase(24, 2, 1978, 33)]
        [TestCase(29, 4, 2014, 22)]
        public void Should_Get_Numerological_Resonance_Of_Date(Int16 day, Int16 month, Int16 year, Int16 expectedResult)
        {
            var date = new DateOnly(year, month, day);
            Check.That(date.NumerologicalResonance()).Equals(expectedResult);
        }
    }
}