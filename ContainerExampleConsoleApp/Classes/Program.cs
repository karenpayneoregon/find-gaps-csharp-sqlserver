using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContainerExampleConsoleApp.Interfaces;
using ContainerExampleConsoleApp.Models;

// ReSharper disable once CheckNamespace
namespace ContainerExampleConsoleApp
{
    internal partial class Program
    {

        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample: Broken sequences/gaps";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

            var rule = new Rule("[yellow]Gap examples[/]")
            {
                Alignment = Justify.Left
            };

            AnsiConsole.Write(rule);
            Console.WriteLine();
        }

        static List<Person> PeopleList() =>
            new()
            {
                new () { Id = 2, FirstName = "Jim", LastName = "Gallagher" },
                new () { Id = 3, FirstName = "Anne", LastName = "Jones"},
                new () { Id = 6, FirstName = "Jean", LastName = "Grey"}
            };

        private static List<IEmployee> EmployeeList() => 
            new()
            {
                new Employee() { Identifier = 1, FirstName = "Joe", LastName = "Adams" },
                new Employee() { Identifier = 2, FirstName = "Mary", LastName = "Smith" },
                new Manager()  { Identifier = 3, FirstName = "Frank", LastName = "O'Brien", 
                    Employees = new List<int>() { 2,5,6 } },
                new Employee() { Identifier = 5, FirstName = "Lee", LastName = "Fux" },
                new Manager()  { Identifier = 6, FirstName = "Sue", LastName = "Gallagher", 
                    Employees = new List<int>() { 1, 3, 8 , 10 } },
                new Employee() { Identifier = 8, FirstName = "Bob", LastName = "Clime" },
                new Employee() { Identifier = 10, FirstName = "Nancy", LastName = "Burger" }
            };


    }
}
