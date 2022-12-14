using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough { get { return dough; } set { dough = value; } }

        public int NumberOfToppings => toppings.Count;

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public double GetTotalCalories()
        {
            double totalCalories = dough.CalculateCalories();
            foreach (Topping topping in toppings)
            {
                totalCalories += topping.CalculateCalories();
            }
            return totalCalories;
        }

        public override string ToString()
        {
            return $"{Name} - {GetTotalCalories():f2} Calories.";
        }
    }
}
