using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));

            while (songs.Count > 0)
            {
                string cmd = Console.ReadLine();

                if (cmd == "Play")
                {
                    songs.Dequeue();
                }
                else if (cmd == "Show")
                {
                    Console.WriteLine(String.Join(", ", songs));
                }
                else
                {
                    string song = cmd.Substring(4);
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
