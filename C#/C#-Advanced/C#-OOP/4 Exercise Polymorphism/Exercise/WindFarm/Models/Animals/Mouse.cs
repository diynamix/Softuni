namespace WindFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Mouse : Mammal
    {
        private const double MouseWeightMultiplier = 0.10;

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PrefferedFood => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit)};

        protected override double WeightMultiplier => MouseWeightMultiplier;

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
