namespace PlayCatch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int exceptions = 0;

            while (exceptions < 3)
            {
                string[] cmdArgs = Console.ReadLine().Split(" ");
                string cmd = cmdArgs[0];

                try
                {
                    int index = int.Parse(cmdArgs[1]);

                    if (cmd == "Replace")
                    {
                        integers[index] = int.Parse(cmdArgs[2]);
                    }
                    else if (cmd == "Print")
                    {
                        List<int> subArray = new List<int>();
                        for (int i = index; i <= int.Parse(cmdArgs[2]); i++)
                        {
                            subArray.Add(integers[i]);
                        }
                        Console.WriteLine(String.Join(", ", subArray));
                    }
                    else if (cmd == "Show")
                    {
                        Console.WriteLine(integers[index]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    exceptions++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    exceptions++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }

            Console.WriteLine(String.Join(", ", integers));
        }
    }
}