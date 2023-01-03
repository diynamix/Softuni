namespace WindFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Dog : Mammal
    {
        private const double DogWeightMultiplier = 0.40;

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PrefferedFood => new HashSet<Type>() { typeof(Meat)};

        protected override double WeightMultiplier => DogWeightMultiplier;

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
