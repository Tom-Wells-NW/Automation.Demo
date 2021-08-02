using ConsoleTableExt;
using System;
using System.Collections.Generic;

namespace Automation.Demo.TestHarness_01
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var examples = new Examples_ConsoleTableExt();
            examples.Example01();

            examples.Example02();

        }
    }

    public class Examples_ConsoleTableExt
    {
        public void Example01()
        {
            var tableData = GetData();

            ConsoleTableBuilder
                .From(tableData)
                .ExportAndWriteLine();
        }

        public void Example02()
        {
            var tableData = GetData();

            ConsoleTableBuilder
                .From(tableData)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .ExportAndWriteLine(TableAligntment.Center);
        }

       
        public List<List<object>> GetData()
        {
            var result = new List<List<object>>
            {
                new List<object>{ new Person(1, "Sakura","Yamamoto"), "Support Engineer", "London", 46},
                new List<object>{ new Person(2, "Serge", "Baldwin"), "Data Coordinator", "San Francisco", 28, "something else" },
                new List<object>{ new Person(3, "Shad", "Decker"), "Regional Director", "Edinburgh"},
            };

            return result;
        }
    }

    public class Person
    {
        public Person(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
