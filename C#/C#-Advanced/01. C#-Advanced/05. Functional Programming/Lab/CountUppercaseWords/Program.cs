using System;
using System.Linq;

class Program
{
    static void Main() =>
        Console.WriteLine(
            String.Join("\r\n", Console.ReadLine()
            .Split(" ")
            .Where(x => x.Length > 0 && char.IsUpper(x[0]))
            .ToArray()));
}


//Predicate<string> isCapitalFirstLetter = (string x) => x.Length > 0 && char.IsUpper(x[0]);
