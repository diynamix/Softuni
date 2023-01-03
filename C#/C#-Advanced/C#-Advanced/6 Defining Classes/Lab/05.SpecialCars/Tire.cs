using System;

namespace CarManufacturer
{
    public class Tire
    {
        //Constructors
        public Tire(int year, double pressure)
        {
            Year = year;
            Pressure = pressure;
        }

        //Fields
        private int year;
        private double pressure;

        //Properties
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value;}
        }
    }
}