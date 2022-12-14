using System;

namespace CarManufacturer
{
    public class Engine
    {
        //Constructor
        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }

        //Fields
        private int horsePower;
        private double cubicCapacity;

        //Properties
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public double CubicCapacity
        {
            get { return cubicCapacity; }
            set { cubicCapacity = value;}
        }
    }
}