using NumerologicalLifePath.Application.CliCommands.Commands;
using NumerologicalLifePath.Application.CliCommands.Wrappers;
using NumerologicalLifePath.Calculators;
using System.CommandLine;

namespace NumerologicalLifePath.Application.CliCommands;

public class BirthDateResonanceStonesCliCommand : SingleCliCommandWrapper<DateOnly>
{
    public BirthDateResonanceStonesCliCommand() : base(new SingleOptionCliCommand<DateOnly>(
                "birthStones",
                "Command to get birth date resonance stones.",
                new Option<DateOnly>(
                    name: "--birthDate",
                    description: "The birthday date DD/MM/YYYY."
                )
                {
                    IsRequired = true
                },
                delegate (DateOnly birthdate)
                {
                    var calculator = new BirthDateResonanceStones();
                    var digits = calculator.Calculate(birthdate);
                    var infos = string.Join("\r\n",
                        digits.Select(digit => $" - {digit.Key} : {digit.Value} - {digit.Value.ConvertToStone()}"));
                    Console.WriteLine($"The BirthDate Resonance Stones are : \r\n{infos}");
                },
                "-d"
        ))
    { }
}

