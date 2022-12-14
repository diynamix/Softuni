namespace WindFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        // TODO: use reflection
        public override IReadOnlyCollection<Type> PrefferedFood => new HashSet<Type> { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        protected override double WeightMultiplier => HenWeightMultiplier;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
