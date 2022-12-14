﻿namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILILITERS = 50;
        private const decimal COFFEE_PRICE = 3.50m;

        public Coffee(string name, double caffeine) : base(name, COFFEE_PRICE, COFFEE_MILILITERS)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
