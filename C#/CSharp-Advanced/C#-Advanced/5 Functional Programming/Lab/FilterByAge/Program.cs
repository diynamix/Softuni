using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    static void Main(string[] args)
    {
        //Read list of people (name + age)
        List<Person> people = ReadInput();

        //Read condition + threshold
        string condition = Console.ReadLine();
        int ageThreshold = int.Parse(Console.ReadLine());

        //Filter all matching people by { condition + threshold }
        Func<Person, bool> filter = PersonFilter(condition, ageThreshold);
        List<Person> matchingPeople = people.Where(filter).ToList();

        //Print all matching people in the specified format
        string format = Console.ReadLine();
        Action<Person> printPerson = FormatPerson(format);
        PrintPeople(matchingPeople, printPerson);
    }

    private static List<Person> ReadInput()
    {
        int n = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split(", ");
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            people.Add(new Person { Name = name, Age = age });
        }
        return people;
    }

    private static Func<Person, bool> PersonFilter(string condition, int ageThreshold)
    {
        if (condition == "older")
        {
            return p => p.Age >= ageThreshold;
        }
        else if (condition == "younger")
        {
            return p => p.Age < ageThreshold;
        }
        throw new ArgumentException($"Invalid filter: {condition} {ageThreshold}");
    }

    static Action<Person> FormatPerson(string format)
    {
        if (format == "name age")
        {
            return p => Console.WriteLine($"{p.Name} - {p.Age}");
        }
        else if (format == "name")
        {
            return p => Console.WriteLine($"{p.Name}");
        }
        else if (format == "age")
        {
            return p => Console.WriteLine($"{p.Age}");
        }
        throw new ArgumentException("Invalid format: " + format);
    }

    static void PrintPeople(List<Person> people, Action<Person> printPerson)
    {
        foreach (Person person in people)
        {
            printPerson(person);
        }
    }
}
