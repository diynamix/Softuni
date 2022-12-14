using System;

namespace DefiningClasses
{
    internal class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = null;
            Efficiency = null;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; }
        public string? Efficiency { get; set; } 
    }
}