namespace WindFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Exceptions;

    public abstract class Animal : IAnimal
    {
        private Animal()
        {
            FoodEaten = 0;
        }

        protected Animal(string name, double weight) : this()
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected abstract double WeightMultiplier { get; }
        public abstract IReadOnlyCollection<Type> PrefferedFood { get; }

        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            if (!PrefferedFood.Any(t => food.GetType().Name == t.Name))
            {
                throw new FoodNotEatenException(String.Format(ExceptionMessages.FoodNotEatenExceptionMessage, this.GetType().Name, food.GetType().Name));
            }

            Weight += food.Quantity * WeightMultiplier;
            FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
