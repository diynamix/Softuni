using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private Dictionary<string, double> calories = new Dictionary<string, double>()
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };

        private const double CALORIES_PER_GRAM = 2;
        private string toppingType;
        private double grams;

        public Topping(string toppingType, double grams)
        {
            ToppingType = toppingType;
            Grams = grams;
        }

        private string ToppingType
        {
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }

        private double Grams
        {
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{toppingType} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }

        public double CaloriesPerGram => CALORIES_PER_GRAM * calories[toppingType.ToLower()];

        public double CalculateCalories()
        {
            return grams * CaloriesPerGram;
        }
    }
}
