using System;
using System.Linq;
using System.Collections.Generic;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int intelligenceValue = int.Parse(Console.ReadLine());
            int currentBullets = gunBarrelSize;
            int shots = 0;

            while (true)
            {
                int bullet = bullets.Pop();
                currentBullets--;
                shots++;
                int curruntLock = locks.Peek();

                if (bullet <= curruntLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currentBullets == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currentBullets = Math.Min(gunBarrelSize, bullets.Count);
                }

                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - shots * bulletPrice}");
                    return;
                }

                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }
            }
        }
    }
}
