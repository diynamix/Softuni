using System;
using System.Linq;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = String.Empty;

                if (tokens.Length > 2)
                {
                    gender = tokens[2];
                }

                if (command == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    result.AppendLine(cat.ToString());
                }
                else if (command == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    result.AppendLine(dog.ToString());
                }
                else if (command == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    result.AppendLine(frog.ToString());
                }
                else if (command == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);
                    result.AppendLine(tomcat.ToString());
                }
                else if (command == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);
                    result.AppendLine(kitten.ToString());
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
