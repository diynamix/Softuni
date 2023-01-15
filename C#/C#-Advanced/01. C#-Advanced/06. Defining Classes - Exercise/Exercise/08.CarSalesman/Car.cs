using System;
using System.Text;

namespace DefiningClasses
{
    internal class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = null;
            Color = null;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string? Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            sb.AppendLine($"    Displacement: {(Engine.Displacement != null ? Engine.Displacement.ToString() : "n/a")}");
            sb.AppendLine($"    Efficiency: {(Engine.Efficiency != null ? Engine.Efficiency : "n/a")}");
            sb.AppendLine($"  Weight: {(Weight != null ? Weight.ToString() : "n/a")}");
            sb.Append($"  Color: {(Color != null ? Color : "n/a")}");

            return sb.ToString();
        }
    }
}