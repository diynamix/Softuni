using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    internal class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Bag = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public List<Product> Bag { get; set; }

        public override string ToString()
        {
            return $"{Name} - {(Bag.Count > 0 ? String.Join(", ", Bag.Select(p => p.Name)) : "Nothing bought")}";
        }
    }
}
