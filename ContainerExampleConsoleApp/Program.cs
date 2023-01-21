using System.Reflection;
using ContainerExampleConsoleApp.Classes;
using ContainerExampleConsoleApp.Models;

namespace ContainerExampleConsoleApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Record();


            var sequence1 = BasicFindMissingIntInMockedArray();
            //Console.WriteLine();
            OutOfOrderExample(sequence1);
            //Console.WriteLine();
            //WithInterfaceExample();
            //Console.WriteLine();
            //ReadFromFileExample();

            Continue();
        }

        /// <summary>
        /// A proper sequence
        /// 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
        /// What we have
        /// 1, 2, 3, 7, 10, 15
        /// Use <seealso cref="Missing"/> to get gaps
        /// </summary>
        /// <returns></returns>
        private static int[] BasicFindMissingIntInMockedArray()
        {
            AnsiConsole.MarkupLine($"[yellow]{nameof(BasicFindMissingIntInMockedArray).SplitCamelCase()}[/]");
            int[] sequence1 = { 1, 2, 3, 7, 10, 15 };

            if (sequence1.IsSequenceBroken())
            {
                AnsiConsole.MarkupLine("[lime]Missing from sequence[/]");
                var values = sequence1.Missing();
                AnsiConsole.MarkupLine($"[b]Are there any?[/] {values.Any().ToYesNoString()}");
                AnsiConsole.MarkupLine(values.JoinWithLastSeparator().Colorize());
            }

            return sequence1;
        }

        /// <summary>
        /// 11, 2, 3, 7, 10, 1 is out of order
        /// ^
        /// |
        ///
        /// We need to first place the elements in order
        /// 1, 2, 3, 7, 10, 11
        /// Then get gaps
        /// </summary>
        /// <param name="sequence1"></param>
        private static void OutOfOrderExample(int[] sequence1)
        {
            AnsiConsole.MarkupLine($"[yellow]{nameof(OutOfOrderExample).SplitCamelCase()}[/]");

            int[] sequence2 = { 11, 2, 3, 7, 10, 1 };
            if (sequence1.IsSequenceBroken())
            {
                AnsiConsole.MarkupLine("[lime]Missing from sequence...[/]");
                var values = sequence2.MissingWrong();
                AnsiConsole.MarkupLine($"[white on blue]Are there any?[/] {values.Any().ToYesNoString()}");
                AnsiConsole.MarkupLine(values.JoinWithLastSeparator().Colorize());
                AnsiConsole.MarkupLine("[white on red]But wait, there are missing elements[/]");
                var correct = sequence2.Missing();
                AnsiConsole.MarkupLine(correct.JoinWithLastSeparator().Colorize());
            }
            else
            {
                AnsiConsole.MarkupLine("[lime]Nothing missing from sequence[/]");
            }

        }

        /// <summary>
        /// In short, we get have an extension method for getting gaps for a specific interface
        /// </summary>
        private static void WithInterfaceExample()
        {
            AnsiConsole.MarkupLine("[yellow]People/Interfaces[/]");
            
            Console.WriteLine();
            
            /*
             * Extension method for interfaces
             */
            var employeeAndManagers = EmployeeList().MissingIdentifiers();
            AnsiConsole.MarkupLine($"[white on blue]Employees and managers:[/] {string.Join(",", employeeAndManagers)}");

        }

        /// <summary>
        /// Read <seealso cref="Contacts"/> and find missing keys
        /// </summary>
        static void ReadFromFileExample()
        {
            AnsiConsole.MarkupLine($"[yellow]{nameof(ReadFromFileExample).SplitCamelCase()}[/]");

            AnsiConsole.MarkupLine("[b]Find[/] missing contact identifiers from file");
            var missingContactIdentifiers = FileOperations.MissingContactIdentifiers();
            AnsiConsole.MarkupLine(missingContactIdentifiers.JoinWithLastSeparator().Colorize());

        }

        private static void Continue()
        {

            AnsiConsole.MarkupLine("[b]Press any key to continue[/]");
            Console.ReadLine();
        }
    }
}