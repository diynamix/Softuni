namespace WindFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PrefferedFood => new HashSet<Type>() { typeof(Vegetable), typeof(Meat) };

        protected override double WeightMultiplier => CatWeightMultiplier;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}