using NumerologicalLifePath.Application.CliCommands.Commands;
using NumerologicalLifePath.Application.CliCommands.Wrappers;
using NumerologicalLifePath.Sdk;
using NumerologicalLifePath.Sdk.Calculators;
using System.CommandLine;

namespace NumerologicalLifePath.Application.CliCommands;

public sealed class InclusionGridCliCommand : TwoOptionsCliCommandWrapper<string, string>
{
    public InclusionGridCliCommand() : base(new TwoOptionsCliCommand<string, string>(
                "inclusionGrid",
                "Command to get the inclusion grid.",
                new Option<string>(
                    name: "--firstName",
                    description: "The first names separated by ' ' and wrapped by '\"'."
                )
                { IsRequired = true },
                new Option<string>(
                    name: "--lastName",
                    description: "The last names separated by ' ' and wrapped by '\"'."
                )                
                { IsRequired = true },
                delegate (string firstNames, string lastNames)
                {
                    var clt = new Client(firstNames, lastNames);
                    var calculator = new InclusionGrid();
                    var digits = calculator.Calculate(clt);
                    var separator = "|";
                    var infos = separator;

                    for (int i = 0; i < digits.Length; i++) {
                        infos += $" {digits[i]} {separator}";
                        if ((i + 1) % 3 == 0 && i!=8) {
                            infos += "\r\n|";
                        } 
                    }

                    Console.WriteLine($"The inclusion grid of {string.Join(" ", firstNames)} {string.Join(" ", lastNames)} are : \r\n{infos}");
                },
                ["-f", "-l"]
        ))
    { }
}
