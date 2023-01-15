using System;

namespace DefiningClasses
{
    internal class Cargo
    {
        public Cargo(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
