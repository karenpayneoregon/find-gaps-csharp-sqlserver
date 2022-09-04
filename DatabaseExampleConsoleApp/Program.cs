using DatabaseExampleConsoleApp.Classes;

namespace DatabaseExampleConsoleApp
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {

            var missingSequence = await DataOperations.GetMissingSequence();

            if (missingSequence.Any())
            {
                AnsiConsole.MarkupLine("[cyan]Found the following missing[/] [yellow]identifiers[/]");
                foreach (var id in missingSequence)
                {
                    Console.WriteLine(id);
                }
            }
            else
            {
                AnsiConsole.MarkupLine("[b]No missing identifiers[/]");
            }
            Console.ReadLine();
        }
    }
}