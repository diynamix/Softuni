namespace WindFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PrefferedFood => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplier => TigerWeightMultiplier;
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
