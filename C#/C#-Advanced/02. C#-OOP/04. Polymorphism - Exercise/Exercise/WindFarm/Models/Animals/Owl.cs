﻿namespace WindFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Owl : Bird
    {
        private const double OwlWeightMultiplier = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PrefferedFood => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplier => OwlWeightMultiplier;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
