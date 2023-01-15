using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Family family = new Family();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] info = Console.ReadLine().Split();
                Person person = new Person(info[0], int.Parse(info[1]));
                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}