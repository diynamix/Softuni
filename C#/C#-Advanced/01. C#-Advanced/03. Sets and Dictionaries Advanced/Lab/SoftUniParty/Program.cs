using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> reg = new HashSet<string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (Char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    reg.Add(input);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (vip.Contains(input))
                {
                    vip.Remove(input);
                }
                else if (reg.Contains(input))
                {
                    reg.Remove(input);
                }
            }

            Console.WriteLine(vip.Count + reg.Count);
            if (vip.Count > 0)
            {
                foreach (string v in vip)
                {
                    Console.WriteLine(v);
                }
            }
            if (reg.Count > 0)
            {
                foreach (string r in reg)
                {
                    Console.WriteLine(r);
                }
            }
        }
    }
}
