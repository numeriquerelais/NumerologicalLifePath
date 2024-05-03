using System.CommandLine;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var fileOption = new Option<FileInfo?>(
           name: "--files",
           description: "The file to read and display on the console.");

var rootCommand = new RootCommand("Sample app for System.CommandLine");
rootCommand.AddOption(fileOption);

rootCommand.SetHandler((file) => { ReadFile(file!);}, fileOption);

return await rootCommand.InvokeAsync(args);

static void ReadFile(FileInfo file)
{
    Console.WriteLine($"I'm reading file {file.FullName}");
}