using NumerologicalLifePath.Application.CliCommands.Commands;
using NumerologicalLifePath.Application.CliCommands.Wrappers;
using NumerologicalLifePath.Sdk;
using NumerologicalLifePath.Sdk.Calculators;
using System.CommandLine;

namespace NumerologicalLifePath.Application.CliCommands;

public sealed class EightLifePathStonesCliCommand : ThreeOptionsCliCommandWrapper<string, string, DateOnly>
{
    public EightLifePathStonesCliCommand() : base(new ThreeOptionsCliCommand<string, string, DateOnly>(
                "lifePath",
                "Command to get the 8 life path stones.",
                new Option<string>(
                    name: "--firstName",
                    description: "The first names separated by \",\" and wrapped by '\"'."
                ) { IsRequired = true },
                new Option<string>(
                    name: "--lastName",
                    description: "The last names separated by \",\" and wrapped by '\"'.\""
                )
                { IsRequired = true },
                new Option<DateOnly>(
                    name: "--birthDate",
                    description: "The birthday date dd/MM/yyyy.",
                    parseArgument: result =>
                    {
                        return result.ConvertArgToDateOnly();
                    }
                )
                { IsRequired = true },
                delegate (string firstNames, string lastNames, DateOnly birthdate)
                {
                    var clt = new Client(birthdate, [.. firstNames.Split(",")], [.. lastNames.Split(",")]);
                    var calculator = new EightLifePathStones();
                    var digits = calculator.Calculate(clt);
                    var infos = string.Join("\r\n",
                        digits.Select(digit => $" - {digit.Key} : {digit.Value} - {digit.Value.ConvertToStone()}"));
                    Console.WriteLine($"The life path stones are : \r\n{infos}");
                },
                ["-f","-l", "-d"]
        ))
    { }

    
}
