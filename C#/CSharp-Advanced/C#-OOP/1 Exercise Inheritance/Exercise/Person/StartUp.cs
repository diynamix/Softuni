using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            if (age > 15)
            {
                var person = new Person(name, age);
                Console.WriteLine(person);
            }
            else
            {
                var child1 = new Child(name, age);
                Console.WriteLine(child1);
            }

            //Child child = new Child(name, age);
            //Console.WriteLine(child);
        }
    }
}